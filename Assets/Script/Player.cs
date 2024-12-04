using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField]  private float distanciaInteraccion;

    private NavMeshAgent agent;
    private Camera cam;

    private  NPC npcActual ; // guardo la Info de un npc actual con el que hablo
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    
    void Update()
    {
        Movimiento();
        if (npcActual)
        {
            // comprobar si he llegado al NPC

            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)

            {
                npcActual.Interactuar(this.transform);
                npcActual = null;
                agent.isStopped= true;
                agent.stoppingDistance = 0;
            }
        }
       
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

                if (hit.transform.TryGetComponent(out NPC npc))
                {
                    // mira a ver si ese npc es el actual 
                    npcActual = npc;

                    // pararme a x metros del enemigo
                    agent.stoppingDistance = distanciaInteraccion;

                }

                agent.SetDestination(hit.point);  // va a ir justo al punto del impacto 

            }
        }
    }
}
