using System;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public float Volume 
    { 
        get 
        { 
            return audioSource.volume; 
        }
        private set 
        { 
            audioSource.volume = value; 
        } 
    } 

    private AudioSource audioSource;

    public void SetVolume(float vol)
    {
        Volume = Mathf.Clamp01(vol);
    }

    public void PlaySound()
    {
        audioSource.Play();
    }

}
