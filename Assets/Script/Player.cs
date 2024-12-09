using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField]  private float distanciaInteraccion;

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
        Movimiento();

        if (ultimoClic && ultimoClic.TryGetComponent(out NPC npc))
        {
            // comprobar si he llegado al NPC
            agent.stoppingDistance = distanciaInteraccion;
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)

            {
                npc.Interactuar(this.transform);
                ultimoClic = null;
                
            }
        }
        else if (ultimoClic)
        {
            agent.stoppingDistance = 0f;
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
                // 
                agent.SetDestination(hit.point);  // va a ir justo al punto del impacto 
                ultimoClic = hit.transform;

            }
        }
    }
}
