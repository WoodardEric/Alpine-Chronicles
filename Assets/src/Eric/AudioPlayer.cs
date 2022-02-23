using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private float volume = 1.0f;

    public AudioSource audioSource;

    public void Play()
    { 
        audioSource.volume = volume;
        audioSource.Play();
    }
}
