using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{
    [SerializeField] FloatVariable health;
    [SerializeField] private PhysicsPlayerController ppc;
    [Header("Events"), SerializeField] IntEvent scoreEvent;
    [SerializeField] VoidEvent startEvent;
    [SerializeField] VoidEvent playerDeadEvent;
    [SerializeField] GameObjectEvent respawnEvent;
    private void OnEnable() {
        startEvent.Subscribe(OnStartGame);
        respawnEvent.Subscribe(OnRespawn);
    }
    private void OnDisable() {
        startEvent.Unsubscribe(OnStartGame);
        respawnEvent.Unsubscribe(OnRespawn);
    }
    public void PickUp(int points, bool spring = true) {
        scoreEvent.RaiseEvent(points);
        if(spring) ppc.increaseJumpForce();
    }

    private void OnStartGame() {
        ppc.enabled = true;
    }

    public void Damage(float value) {
        health.value -= value;
        if(health.value <= 0) playerDeadEvent.RaiseEvent();
    }
    
    public float Health {get {return health.value;} set {health.value = value;}}

    private void Start() {
        health.value = 100;
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.R)) {
            Damage(999);
        }
    }
    
    public void OnRespawn(GameObject respawn) {
        //if(respawnObject == null) respawnObject = GameObject.FindObjectOfType<CheckpointManager>().gameObject;
        transform.position = respawn.transform.position;
        transform.rotation = respawn.transform.rotation;
        ppc.reset();
    }
}
