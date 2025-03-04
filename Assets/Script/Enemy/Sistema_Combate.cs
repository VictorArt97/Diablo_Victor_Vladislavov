using System;
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
    [SerializeField] private float danhoAtaque;
    [SerializeField] private NavMeshAgent agent;
    private Transform target;
    [SerializeField] private Animator anim;
    // awake vs onEnable vs Start 
    private void Awake()
    {
        main.Combate = this;
        
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
            EnfocarObjetivo();

            // voy persiguiendo al targer en todo momento 
            agent.SetDestination(main.MainTarget.position);
            if (!agent.pathPending && agent.stoppingDistance<=distanciaAtaque)
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

    #region Ejecutados por ejentos de animacion
    private void Atacar()
    {
        // al poseer su transform puedo acceder a su codigo
        main.MainTarget.GetComponent<Player>().HacerDanho(danhoAtaque);
    }
    private void FinAnimacionAtaque()
    {
        anim.SetBool("Attacking", false);
    }
    #endregion
    private void EnfocarObjetivo()
    {
        Vector3 direccionATarget = (main.MainTarget.position - this.transform.position).normalized;
        direccionATarget.y = 0;

        Quaternion rotacionATarget = Quaternion.LookRotation(direccionATarget);
        transform.rotation = rotacionATarget;
    }

    // hacer un evento de animacion en el momento en el que el enemigo ataca 
    // hacer el script EnemyVisual y anadirlo a EnemyVisual 
    //en ese script a�adir el metodo Atacar que sea lanzado cuando se cumple el evento de Animacion
}
