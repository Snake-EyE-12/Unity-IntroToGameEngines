using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject pickupEffect;
    [SerializeField] private AudioClip sound;
    [SerializeField] private int value;
    [SerializeField] private int volume = 1;
    [SerializeField] private bool increaseJump = true;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.TryGetComponent(out Player player)) {
            player.PickUp(value, increaseJump);
            AudioManager.Instance.Play(sound, volume);
        }
        Instantiate(pickupEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
