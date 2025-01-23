using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour,Iinteractuable
{
    private Outline outline;

    [SerializeField] private Texture2D cursorInteraccion;
    [SerializeField] private Texture2D cursorPorDefecto;
    [SerializeField] private float tiempoDeGiro;

    [SerializeField] private Transform cameraPoint;

    [SerializeField] private DialogaSO dialogo;
    


    void Start()
    {
        outline = GetComponent<Outline>();
    }

    public void Interactuar(Transform interactuador)
    {
        transform.DOLookAt(interactuador.transform.position, tiempoDeGiro, AxisConstraint.Y).OnComplete(()=> SistemaDeDialogo.sistema.IniciarDialogo(dialogo,cameraPoint));      
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
