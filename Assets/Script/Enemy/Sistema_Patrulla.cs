using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sistema_Patrulla : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    [SerializeField] private Transform ruta;

   [SerializeField] private NavMeshAgent agent;
    private Vector3 destinoActual;  // marca el destino al cual tenemos que ir 

    List<Vector3> listadoPuntos = new List<Vector3>(); // la diferencia con un array es que su longitud es variable 
    private int indiceActualRuta=-1;

    [SerializeField] private float velocidadPatrulla;



    private void Awake()
    {
       
        // comunico al main que el sistema de patrulla soy yo
        main.Patrulla = this;

        foreach (Transform punto in ruta)
        {
            //y los añado en mi lista 

            listadoPuntos.Add(punto.position);
        }
        CalcularDestino();

    }
    void Start()
    {

    }

    private void OnEnable()
    {
        indiceActualRuta = -1; // empiezo desde el comienzo 
        agent.speed = velocidadPatrulla; // vuelvo a la velocidad de patrulla
        
        // voy recorriendo todos los putnos que tiene mi ruta  
        StartCoroutine(PatrullarYEsperar());
    }

    private IEnumerator PatrullarYEsperar()
    {
        while (true)   
        {
            CalcularDestino();  // 1) se calculara un nuevo destino
            agent.SetDestination(destinoActual);            // 2) se te marca dicho destino

            yield return new WaitUntil(()=>!agent.pathPending && agent.remainingDistance<=0.2f) ;   /// espera hasta que llegues al punto 
            yield return new WaitForSeconds(Random.Range(0.5f,1.5f));// una vez llegado al punto esperamos x tiempo
        }
       
    }

    private void CalcularDestino()
    {
        indiceActualRuta++;
        // count es lo mismo que Lenght en los arrays 
        if(indiceActualRuta >= listadoPuntos.Count)   // si no me quedanpuntos volvere al punto 0
        {
            indiceActualRuta = 0;
        }

        destinoActual = listadoPuntos[indiceActualRuta];
    }
    private void OnTriggerEnter(Collider other)  // atraves de un rango de vision el enemigo puede verme con una capsula
    {
        // 1) mirar a ver si lo que entra en mi campo es el player 
        // 2) si es el parar todas las corrutinas
        // 3) desactivar este script y activar el sistema combate 

        if (other.CompareTag("Player"))
        {
            this.enabled = false;     // deshabilito patrulla
            StopAllCoroutines();   // paro Corrutinas
            main.ActivaCombate(other.transform);   

        }
    }
}
