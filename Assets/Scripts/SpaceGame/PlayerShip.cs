using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Interactable
{
    [SerializeField] private Action action;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private float health = 100;

    private void Start()
    {
        action.onEnter += OnInteractStart;
        action.onStay += OnInteractActive;
    }

    private void Update()
    
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _inventory.Use();
        }
    }

    public override void OnInteractStart(GameObject gameObject)
    {
        
    }

    public override void OnInteractActive(GameObject gameObject)
    {
        
    }

    public override void OnInteractEnd(GameObject gameObject)
    {
        throw new NotImplementedException();
    }
}
