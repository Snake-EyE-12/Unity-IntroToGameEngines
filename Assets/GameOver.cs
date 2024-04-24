using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void Awake()
    {
        Destroy(this.gameObject, 70);
    }

    
    private void OnDestroy()
    {
        GameManager.Instance.OnPlayerDied();
    }
}
