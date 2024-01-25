using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public float turnRate;

    private void Update() {
        transform.rotation *= Quaternion.AngleAxis(turnRate * Time.deltaTime, Vector3.up);
    }
}
