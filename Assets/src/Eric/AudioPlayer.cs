using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private float volume = 0.5f;

    public AudioSource audioSource;

    public void Play()
    { 
        audioSource.volume = volume;
        audioSource.Play();
    }
}
