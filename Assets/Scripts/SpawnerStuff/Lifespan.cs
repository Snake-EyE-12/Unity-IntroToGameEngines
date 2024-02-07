using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifespan : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float time = 1;
    
    private void Start()
    {
        Destroy(this.gameObject, time);
    }
}
