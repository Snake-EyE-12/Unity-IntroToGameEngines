using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float damage = 2;
    [SerializeField] private bool constant = true;
    [SerializeField] private AudioClip clip;
    private void OnTriggerEnter(Collider other) {
        if(!constant && other.TryGetComponent(out Player player)) {
            player.Damage(damage);
        }
        if(clip != null) {
            AudioManager.Instance.Play(clip, 3);
        }
    }

    private void OnTriggerStay(Collider other) {
        if(constant && other.TryGetComponent(out Player player)) {
            player.Damage(damage * Time.deltaTime);
        }
    }
}

