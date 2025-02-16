using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour,Iinteractuable
{
    [SerializeField] private EventManagerSO eventManager;
    [SerializeField] private MisionSO misionAsociada;


    private Outline outline;

    [SerializeField] private Texture2D cursorInteraccion;
    [SerializeField] private Texture2D cursorPorDefecto;
    [SerializeField] private float tiempoDeGiro;

    [SerializeField] private Transform cameraPoint;

    [SerializeField] private DialogaSO dialogoPreMision;
    [SerializeField] private DialogaSO dialogoPostMision;
    [SerializeField] private DialogaSO dialogoActual;

    [SerializeField] private GameObject barrera;


    private void Awake()
    {
        dialogoActual = dialogoPreMision;
    }
    void Start()
    {
        outline = GetComponent<Outline>();
        barrera.SetActive(false);
    }

    public void Interactuar(Transform interactuador)
    {
        transform.DOLookAt(interactuador.transform.position, tiempoDeGiro, AxisConstraint.Y).OnComplete(()=> SistemaDeDialogo.sistema.IniciarDialogo(dialogoActual,cameraPoint));      
    }

    private void OnEnable()
    {
        // me suscribo al evento para estar atento de cuando cambiar el dialogo
        eventManager.OnTerminarMision += CambiarDialogo;
    }

    private void CambiarDialogo(MisionSO misionTerminada)
    {
        if(misionTerminada == misionAsociada)
        {
            dialogoActual = dialogoPostMision;

            barrera.SetActive(true);
        }
    }
    

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorInteraccion, Vector2.zero, CursorMode.Auto);
        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorPorDefecto, Vector2.zero, CursorMode.Auto);
        outline.enabled = false;
    }
}
