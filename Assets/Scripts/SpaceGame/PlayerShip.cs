using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Interactable
{
    [SerializeField] private Action action;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private float health = 100;
    [SerializeField] private IntEvent scoreEvent;

    [SerializeField] private AudioSource audio;
    private float score;
    [SerializeField] private AudioClip clip;

    private void AddPoints(int p)
    {
        score += p;
        
    }

    private void Start()
    {
        //scoreEvent.Subscribe(AddPoints);
        if (action != null)
        {
            action.onEnter += OnInteractStart;
            action.onStay += OnInteractActive;
        }
    }

    private void Update()
    
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            audio.clip = clip;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            _inventory.Use();
            audio.Play();
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
