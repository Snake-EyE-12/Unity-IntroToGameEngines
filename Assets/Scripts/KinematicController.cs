using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicController : MonoBehaviour, IDamagable
{
    [SerializeField] private float speed = 1;
    [SerializeField] private float maxDistance = 5;

    private float health = 100;

    private void Update() {
        
        

        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        Vector3 force = direction * speed * Time.deltaTime;
        transform.localPosition += force;

        
        transform.localPosition = ClampRadius(transform.localPosition, Vector3.zero, maxDistance);
        
    }
    private Vector3 ClampRadius(Vector3 position, Vector2 center, float radius)
    {
        if (Vector2.Distance(position, center) > radius)
        {
            return center + ((Vector2)position - center).normalized * radius;
        }

        return position;
    }


    public void ApplyDamage(float damage)
    {
        health -= damage;
    }
}
