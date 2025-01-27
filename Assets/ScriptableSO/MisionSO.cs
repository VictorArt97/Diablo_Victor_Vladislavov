using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Mision")]
public class MisionSO: ScriptableObject
{
    public string ordenInicial;// recoge...
    public string ordenFinal;// vuelve a hablar con...
   
    public bool repetir; // Si la Mision tiene varios pasos
    public int repeticionesTotales;

    public int estadoActual;

    public int indiceMision;// identificador Unico
}  
