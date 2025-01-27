using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager;
    [SerializeField] private ToggleMision [] toggleMision;
   

    // Update is called once per frame
    private void OnEnable()
    {
        eventManager.OnNuevaMision += ActivarToggleMision;
        eventManager.OnActualizarMision += ActualizarToggle;
        eventManager.OnTerminarMision += CerrarToggle;
    }


    private void ActivarToggleMision(MisionSO mision)
    {
        toggleMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;

        if (mision.repetir)
        {
            toggleMision[mision.indiceMision].TextoMision.text += "("+mision.estadoActual+"/"+mision.repeticionesTotales+")";
        }
        
        toggleMision[mision.indiceMision].gameObject.SetActive(true);
    }
    private void ActualizarToggle(MisionSO mision)
    {
        
    }
    private void CerrarToggle(MisionSO mision)
    {
        toggleMision[mision.indiceMision].Toggle.isOn = true;
    }
}
