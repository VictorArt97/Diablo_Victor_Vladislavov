using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private Sistema_Combate combate;
    private Sistema_Patrulla patrulla;
    private Transform mainTarget;
    public Sistema_Combate Combate { get => combate; set => combate = value; }
    public Sistema_Patrulla Patrulla { get => patrulla; set => patrulla = value; }
    public Transform MainTarget { get => mainTarget; }

    private void Start()
    {
        // empieza el juego y activamos la patrulla
        patrulla.enabled = true;
    }
    internal void ActivaCombate(Transform target)
    {
        // ahora tenemos un target al cual perseguir
        mainTarget = target;
        // nos dicen de activar el combate
        combate.enabled = true;
    }
}
