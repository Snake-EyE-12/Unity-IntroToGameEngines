using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public float speed;
    public float limit;
    Vector3 initPos;
    // Update is called once per frame
    private void Start() {
        initPos = transform.position;
    }
    void Update()
    {
        transform.position += Vector3.forward * speed;
        if(transform.position.z > limit) transform.position = initPos;
    }
}
