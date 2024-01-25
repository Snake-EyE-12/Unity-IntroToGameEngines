using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float offset;
    [SerializeField] private float defaultPitch;
    [SerializeField] private float defaultYaw;
    [SerializeField] private float sensitivity = 0.4f;
    [SerializeField] private GameObjectEvent reset;
    private void Awake() {
        reset.Subscribe(allowMovement);
    }
    private void OnDisable() {
        reset.Unsubscribe(allowMovement);
    }
    private bool canMove = false;
    private float yaw;
    private float pitch;
    private void Start() {
        yaw = defaultYaw;
        pitch = defaultPitch;
    }
    private void allowMovement(GameObject o) {
        canMove = true;
        transform.rotation = o.transform.rotation;
        yaw = transform.rotation.y * 180;
        pitch = defaultPitch;
    }
    private void disableMovement() {
        canMove = false;
    }
    private void Update() {
        if(!canMove) return;
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch += Input.GetAxis("Mouse Y") * sensitivity;

        Quaternion qyaw = Quaternion.AngleAxis(yaw, Vector3.up);

        Quaternion qpitch = Quaternion.AngleAxis(pitch, Vector3.right);

        Quaternion rotation = qyaw * qpitch;

        transform.position = target.position + (rotation * Vector3.back * offset);
        transform.rotation = rotation;
    }
}
