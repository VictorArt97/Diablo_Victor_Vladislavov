using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName= "Dialogo")]
public class DialogaSO : ScriptableObject
{
    [TextArea]
    public String [] frases;
    public float tiempo;


    public bool tieneMision;
   // public string textoMision;
   public MisionSO mision;

 
   
  
  
}
