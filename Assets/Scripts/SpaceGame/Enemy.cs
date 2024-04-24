using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable

{
    [SerializeField] private float health;
    [SerializeField] private int points;
    [SerializeField] private IntEvent scoreEvent;

    [SerializeField] private GameObject destroyPrefab;
    [SerializeField] private GameObject hitPrefab;
    
    
    public void ApplyDamage(float damage)
    {
        health -= damage;
        if (health <= damage)
        {
            //scoreEvent?.RaiseEvent(points);
            GameManager.Instance.OnAddPoints(points);
            if (destroyPrefab != null)
            {
                Instantiate(destroyPrefab, transform.position, quaternion.identity);
            }
            Destroy(gameObject);
        }
        else
        {
            if(hitPrefab != null) Instantiate(hitPrefab, transform.position, Quaternion.identity);
        }
    }
    
}
