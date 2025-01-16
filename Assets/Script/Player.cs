using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField]  private float distanciaInteraccion;
    [SerializeField] private float tiempoDeGiro;


    private NavMeshAgent agent;
    private Camera cam;

    private  Transform ultimoClic ; // guardo la Info de un npc actual con el que hablo
   
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    
    void Update()
    {
        if (Time.timeScale ==1 )
        {
             Movimiento();
        }
        if (ultimoClic && ultimoClic.TryGetComponent(out Iinteractuable interactuable))
        {
                // comprobar si he llegado al NPC
                agent.stoppingDistance = distanciaInteraccion;
                if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
                {
                    // traves de lookAt consigue que el jugador mire al NPC
                    // Yuna vez complete el giro estas 2 lineas
                    // transform.DOLookAt(npc.transform.position,tiempoDeGiro, AxisConstraint.Y).OnComplete(()=>LanzarInteraccion(npc));
                    LanzarInteraccion(interactuable);
                }
        }
        
        else if (ultimoClic)
        {
             agent.stoppingDistance = 0f;
        }
              
    }

    private void LanzarInteraccion(Iinteractuable interactuable)
    {
        interactuable.Interactuar(transform);
        ultimoClic = null;

    }

    private void Movimiento()
    {
        // trazar un raycast desde la poscion de la camara a la posicion del raton

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);  // se mide en pixeles 
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Mirar a ver si el punto donde he impactado tiene el script NPC
                // 
                agent.SetDestination(hit.point);  // va a ir justo al punto del impacto 
                ultimoClic = hit.transform;

            }
        }
    }

    internal void HacerDanho(float danhoAtaque)
    {
        Debug.Log("me han hecho " + danhoAtaque + "de daño en los huevos");
    }
}
