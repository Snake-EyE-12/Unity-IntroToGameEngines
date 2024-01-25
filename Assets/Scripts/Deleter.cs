using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deleter : MonoBehaviour
{
    private void Awake() {
        Destroy(this.gameObject, 2.0f);
    } 
}
