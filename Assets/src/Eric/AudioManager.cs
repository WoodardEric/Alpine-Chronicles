using UnityEngine;

/*
* Summary: Abstract class for any kind of AudioManager subclass. Defines common audio source
* methods like muting and setting the volume.
* 
* Member Variables:
* audioSource - A unity object that is responsible for playing audio clips.
*/
public abstract class AudioManager : MonoBehaviour
{
    /*
    * Summary: Abstract method that should be defined to initilize the child class.
    * Unity calls this function at the start of a new scene.
    */
    abstract public void Awake();
    /*
    * Summary: Abstract method that should be defined to read sound files from the
    * resource folder into soundclips to be played by the audio source. 
    */
    protected abstract void ReadClips();

    /*
     * Summary: Toggle muting the AudioSource
     */
    public void Mute()
    {
        Source.mute = !Source.mute;
    }

    public AudioSource Source
    {
        get;
        protected set;
    }

    /*
     * Summary: Volume property for the audio source. Set and get the  audio source Volume
     * 
     * Parameters:
     * value - Float number to set the volume between 0-1
     * 
     * Return:
     * Float - current audio source volume
     */
    public float Volume
    {
        get
        {
            return Source.volume;
        }
        protected set
        {
            Source.volume = value;
        }
    }


    /*
    * Summary: Public volume setter. Sets the audio source volume to a
    * value and clamps it between 0 and 1.0f
    * 
    * Parameters:
    * vol - The float value to change the volume to
    */
    public void SetVolume(float vol)
    {
        Volume = Mathf.Clamp01(vol);
    }
}
