using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {

        // para que la barra mire a la camara ( solo exclusivamente en ortografica)
        transform.forward = -cam.transform.forward;
    }
}
