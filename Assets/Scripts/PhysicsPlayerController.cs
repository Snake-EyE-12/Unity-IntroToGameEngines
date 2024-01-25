using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsPlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    Vector3 force = Vector3.zero;
    [SerializeField] Transform view;
    [SerializeField] private float rayLength;
    [SerializeField] private LayerMask groundLayerMask;
    private float jumpForceStartingValue;
    private void Start() {
        rb = GetComponent<Rigidbody>();
        jumpForceStartingValue = jumpForce;
    }
    public void increaseJumpForce() {
        jumpForce++;
    }
    private void Update() {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        Quaternion yRotation = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up);

        force = yRotation * direction * speed;


        if(Input.GetButtonDown("Jump") && CheckGround()) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void FixedUpdate() {
        rb.AddForce(force, ForceMode.Force);
    }
    private bool CheckGround() {
        Debug.DrawRay(transform.position, Vector3.down * rayLength, Color.red, 0.5f);
        return Physics.Raycast(transform.position, Vector3.down, rayLength, groundLayerMask);
    }
    public void reset() {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        jumpForce = jumpForceStartingValue;
    }
}
