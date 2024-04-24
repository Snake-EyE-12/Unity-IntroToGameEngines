using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileAmmo : Ammo
{
    [SerializeField] private Action action;
    // Start is called before the first frame update
    void Start()
    {
        if (action != null)
        {
            action.onEnter += OnInteractStart;
            action.onStay += OnInteractActive;
        }
        if (ammoData.force != 0) GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * ammoData.force, ammoData.forceMode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyDamage(10);
        }
    }
}
