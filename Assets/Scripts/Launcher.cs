using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private float force;
    private void OnTriggerStay(Collider other) {
        if(other.TryGetComponent<Rigidbody>(out Rigidbody rb)) {
            rb.AddForce(transform.up * force, ForceMode.Impulse);
        }
    }
}
