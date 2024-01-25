using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disco : MonoBehaviour
{
    Light light;
    int color;
    private void Start() {
        light = GetComponent<Light>();
    }

    private void Update() {
        color++;
        if(color > 255) color = 0;
        light.color = Color.HSVToRGB(color / 255.0f, 1, 1);
    }
}
