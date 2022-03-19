using UnityEngine;

public abstract class AudioManager : MonoBehaviour
{
    public void Mute()
    {
        audioSource.mute = !audioSource.mute;
    }

    abstract protected void Awake();

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

    protected AudioSource audioSource;

    public void SetVolume(float vol)
    {
        Volume = Mathf.Clamp01(vol);
    }

    protected abstract void ReadClips();

}
