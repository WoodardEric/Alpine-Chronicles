using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private float volume = 0.2f;

    public AudioSource audioSource;

    public void PlaySound()
    {
        audioSource.volume = volume;
        audioSource.Play();
        Debug.Log("Sound Played!");
    }

}
