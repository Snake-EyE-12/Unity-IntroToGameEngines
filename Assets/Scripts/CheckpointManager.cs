using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : Singleton<CheckpointManager>
{
    
    private int currentValue = 0;
    [SerializeField] private Transform checkPointRespawner;
    public void ChangeCheckPoint(CheckPointDetection detector, bool mandatory = false) {
        if(detector.value > currentValue || mandatory) {
            currentValue = detector.value;
            checkPointRespawner.position = detector.transform.position;
            checkPointRespawner.rotation = detector.transform.rotation;
            detector.gameObject.SetActive(false);
        }
    }
}
