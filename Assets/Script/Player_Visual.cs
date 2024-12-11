using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Visual : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

  
    void Update()
    {
        anim.SetFloat("Velocity", );
    }
}
