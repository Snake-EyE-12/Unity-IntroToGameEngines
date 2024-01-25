using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float force;
    public Rigidbody rb;
    private void Update() {
        
        if(Input.GetKeyDown(KeyCode.Space)) rb.AddForce(force * Vector3.up, ForceMode.VelocityChange);
    }
}
