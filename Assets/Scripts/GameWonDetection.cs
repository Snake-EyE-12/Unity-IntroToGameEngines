using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWonDetection : MonoBehaviour
{
    [SerializeField] private VoidEvent GameWon;
    
    private void OnTriggerEnter(Collider other) {
        GameWon.RaiseEvent();
    }
}
