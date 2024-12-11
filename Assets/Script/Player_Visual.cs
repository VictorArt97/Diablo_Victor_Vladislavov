using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player_Visual : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private NavMeshAgent agent;



    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        // velocidad maxima :
       // agent.speed


        // velocidad Actual :
        // agent.velocity
    }

  
    void Update()
    {
        // todos los frames voy actualizando mi velocity en funcion de mi velocidad actual 
        anim.SetFloat("Velocity", agent.velocity.magnitude / agent.speed );
    }
}
