using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private Sistema_Combate combate;
    private Sistema_Patrulla patrulla;
    private Transform target;
    public Sistema_Combate Combate { get => combate; set => combate = value; }
    public Sistema_Patrulla Patrulla { get => patrulla; set => patrulla = value; }
    public Transform MainTarget { get => target; }

    private void Start()
    {
        // empieza el juego y activamos la patrulla
        patrulla.enabled = true;
    }
    public void ActivaCombate(Transform target)
    {
        Debug.Log("wasaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        // ahora tenemos un target al cual perseguir
        this.target = target;
        // nos dicen de activar el combate
        combate.enabled = true;
    }

    public void ActivarPatrulla()
    {
        combate.enabled = false;
        patrulla.enabled = true;
    }
}
