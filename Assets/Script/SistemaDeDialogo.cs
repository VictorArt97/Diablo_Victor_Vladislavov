using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SistemaDeDialogo : MonoBehaviour
{
    // patron SingleTon   ( Que hace)
    // asegura que esta sea la UNICA instancia de SistemaDialogo
    //  asegura que esa instncia sea accesible desde cualquier punto del programa 

    // una pregunta estatica no es una que no puedas cambiar , sino que ahce que pertenezca a la clase ( fabrica ) y no a las instancias de la clase ( productos)

   // referencia al gamobjectr marcos y cuando private void OnConnectedToServer()
    
    //    inicie un dialogo 
    
    public static SistemaDeDialogo sistema;
    [SerializeField] GameObject marcos;
    [SerializeField] private TMP_Text textoDialogo;

    private bool escribiendo; // para saber si esta escribiendo o no
    private int indiceFraseActual;

    

    private void Awake()
    {
        // si el trono se queda vacio ...
        if (sistema == null)
        {
            // reclamo el trono y me lo quedo 
            sistema = this;

            // no me destruyo entre escenas
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IniciarDialogo(DialogaSO dialogo)
    {
        marcos .SetActive(true);

    }

    private void EscribirFrase()
    {

    }

    private void SiguienteFrase()
    {

    }

    private void TerminarDialogo()
    {

    }

}
