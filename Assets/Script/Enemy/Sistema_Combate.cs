using System.Collections;
using System.Collections.Generic;
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

    // awake vs onEnable vs Start 
    private void Awake()
    {
        main.Combate = this;
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        agent.speed = velodiadCombate;
        agent.stoppingDistance= distanciaAtaque;
    }

    // Update is called once per frame
    void Update()
    {
        agent.speed = velodiadCombate;
        target = main.MainTarget;
        agent.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
