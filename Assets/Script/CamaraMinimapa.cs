using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMinimapa : MonoBehaviour
{
   [SerializeField] private Player player;
    private Vector3 distanciaAPlayer;
    void Start()
    {
        distanciaAPlayer= transform.position- player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // mi poscion en todos los frames es la del player MAS cierta distancia
        transform.position = player.transform.position + distanciaAPlayer;
    }
}
