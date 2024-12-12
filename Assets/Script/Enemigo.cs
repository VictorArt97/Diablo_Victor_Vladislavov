using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private Transform ruta;

    private NavMeshAgent agent;
    private Vector3 destinoActual;  // marca el destino al cual tenemos que ir 

    // la diferencia con un array es que su longitud es variable 

    List<Vector3> listadoPuntos = new List <Vector3>();

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>(); 
        
        foreach (Transform punto in ruta)
        {
            //y los añado en mi lista 

            listadoPuntos.Add(punto.position);
        }
        CacularDestino();

    }
    void Start()
    {
        // voy recorriendo todos los putnos que tiene mi ruta  
        StartCoroutine(PatrullarYEsperar());
       
    }

    private IEnumerator PatrullarYEsperar()
    {
        agent.SetDestination(destinoActual);
        yield return null;
    }

    private void CacularDestino()
    {
        destinoActual = listadoPuntos[0];
    }
   
}
