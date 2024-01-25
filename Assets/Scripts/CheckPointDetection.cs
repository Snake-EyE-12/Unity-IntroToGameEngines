using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointDetection : MonoBehaviour
{
    public int value;
    [SerializeField] private AudioClip clip;
    private void OnTriggerEnter(Collider other) {
        CheckpointManager.Instance.ChangeCheckPoint(this);
        if(clip != null) {
            AudioManager.Instance.Play(clip);
        }
    }
    private void Update() {
        if(Input.GetKeyDown((KeyCode)(48 + value))) CheckpointManager.Instance.ChangeCheckPoint(this, true);
    }

}
