using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    private Outline outline;

    [SerializeField]private Texture2D cursorInteraccion;
    [SerializeField]private Texture2D cursorPorDefecto;

    // antes del start , este o no este habilitado el cript , el awake se lanza pero el start no
    private void Awake()
    {
        outline = GetComponent<Outline>();
    }


    void Start()
    {
       
    }

    
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorInteraccion,Vector2.zero,CursorMode.Auto);
        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorPorDefecto,Vector2.zero,CursorMode.Auto);
        outline.enabled = false;
    }
}
