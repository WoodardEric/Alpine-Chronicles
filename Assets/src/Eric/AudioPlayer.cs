using System;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private float volume = 0.2f;

    public AudioSource audioSource;

    public void setVolume(float vol)
    {
        audioSource.volume = Mathf.Clamp01(vol);
    }

    public void PlaySound()
    {
        audioSource.Play();
    }

}
