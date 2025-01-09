using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Sistema_Combate : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    // Start is called before the first frame update

    // 1) define una velocidad de combate (variable)
    //2) referencia al navmesh Agent con el que nos vamos a mover 
    //3) marca como destino constantemente( update) al target definido en main
    [SerializeField] private float velodiadCombate;
    [SerializeField] private float distanciaAtaque;
    [SerializeField] private NavMeshAgent agent;
    private Transform target;
     private Animator anim;
    // awake vs onEnable vs Start 
    private void Awake()
    {
        main.Combate = this;
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        agent.speed = velodiadCombate;
        agent.stoppingDistance= distanciaAtaque;
    }

    // Update is called once per frame
    void Update()
    {
        // si existe un mainTarget y ese target es alcanzable  su el target  es alcanzable 
        
        if (main.MainTarget && agent.CalculatePath(main.MainTarget.position, new NavMeshPath())) 
        {
            // voy persiguiendo al targer en todo momento 
            agent.SetDestination(main.MainTarget.position);
            if (distanciaAtaque<=0)
            {
                anim.SetBool("Attacking" , true);
            }

            // si el objetivo esta a distancia de ataque ---> lanzar animacion
            //introducir animator la animacion 
            //conf su parametro (bool)
            //lanzar el parametro para que se ejecute la animacion

        }
        else //si no e
        {
            main.ActivarPatrulla();
        }
    }

   

}
