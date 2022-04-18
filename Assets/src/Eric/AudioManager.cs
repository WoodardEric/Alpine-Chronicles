using UnityEngine;

public abstract class AudioManager : MonoBehaviour
{
    protected AudioSource audioSource;
    abstract protected void Awake();
    protected abstract void ReadClips();


    public void Mute()
    {
        audioSource.mute = !audioSource.mute;
    }


    public float Volume
    {
        get
        {
            return audioSource.volume;
        }
        protected set
        {
            audioSource.volume = value;
        }
    }


    public void SetVolume(float vol)
    {
        Volume = Mathf.Clamp01(vol);
    }
}
