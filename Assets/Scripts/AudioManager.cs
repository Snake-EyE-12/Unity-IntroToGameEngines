using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource source;
    public void Play(AudioClip sound, float volume = 1) {
        source.PlayOneShot(sound, volume);
    }
}
