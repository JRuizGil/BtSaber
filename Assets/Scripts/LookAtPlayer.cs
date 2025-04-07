using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [Header("Referencia al objeto del jugador")]
    public Transform objetivo;

    void Update()
    {
        if (objetivo != null)
        {            
            transform.LookAt(objetivo);
        }
    }
}
