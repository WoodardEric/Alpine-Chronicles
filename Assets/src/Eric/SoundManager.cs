using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


/*
* Summary: AudioManager sublcass that Controls playing all in-game sound effects
* 
* Member Variables:
* clips - a dictionary of all avialbe music tracks. Key is a MusicTrack enum that maps to a Sound object
*/
public class SoundManager : AudioManager
{
    private readonly Dictionary<SoundEffect, Sound> clips = new Dictionary<SoundEffect, Sound>();


    /*
    * Summary: Instance Property get and set the SoundManager instance for this singleton class.
    * 
    * Parameters:
    * MusicManager - the current instance of a SoundManager class
    * 
    * return:
    * MusicManger - returns the only allowed instance of a SoundManager class.
    */
    public static SoundManager Instance 
    { 
        get; 
        private set; 
    }


    /*
    * Summary: initilize the the MusicManager to set the instance if
    * creating for the first time. Else destory the MusicManager trying to
    * be created.
    */
    public override void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Source = gameObject.AddComponent<AudioSource>();
            Volume = 0.4f;
            Instance = this;
            ReadClips();
            DontDestroyOnLoad(this);
        }
    }


    /*
    * Summary: Use to play a soundeffect in game
    * 
    * Parameters:
    * soundeffect - soundeffect that will be played.
    */
    public void Play(SoundEffect soundEffect)
    {
        Sound sound = clips[soundEffect];
        AudioClip clip;
        if (sound.IsVariant)
        {
            clip = GetRandomVariant(soundEffect);
        }
        else
        {
            clip = sound.clip;
        }
        
        if(sound.IsMusical)
        {
            MusicManager.Instance.DuckMusic(clip.length);
        }
        Source.PlayOneShot(clip);
    }


    /*
    * Summary: Loads all soundeffect files in the Sounds folder in the resources directory
    * as a audioclip and adds it to the clips dictionary.
    */
    protected override void ReadClips()
    {
        foreach (SoundEffect effect in Enum.GetValues(typeof(SoundEffect)))
        {
            clips.Add(effect, new Sound(effect));
        }
    }


    /*
    * Summary: Get a random variant for a soundeffect. Used to add variation to
    * common sounds like the attack sound.
    * 
    * Parameters:
    * sound - the base sound to be played
    */
    private AudioClip GetRandomVariant(SoundEffect sound)
    {
        var clipVariants = new List<AudioClip>();
        foreach (KeyValuePair<SoundEffect, Sound> clip in clips)
        {
            if (clip.Value.clip.name.Contains(sound.ToString()))
            {
                clipVariants.Add(clip.Value.clip);
            }
        }

        return clipVariants[Random.Range(0, clipVariants.Count)];
    }


    /*
    * Summary: List of the avialbe sound effects that can be used in the game
    */
    public enum SoundEffect
    {
        Attack,
        AttackOne,
        AttackTwo,
        Coin,
        Damage,
        DoorOpen,
        Fanfare,
        Key,
        LockedDoor,
        Select,
    }


    /*
    * Summary: A struct to organize flags for a soundeffect
    * 
    * Member Variables:
    * clip - the audioclip that is played by an audio source
    * IsVariant - true if the Sound has variants
    * IsMusical - true if the Sound is a small musical piece that should duck the music
    */
    private class Sound
    {
        public AudioClip clip;
        public bool IsVariant = false;
        public bool IsMusical = false;

        /*
        * Summary: Constructor to initilze all the member varialbes and read
        * the soundeffect file into the clip
        */
        public Sound(SoundEffect soundEffect)
        {
            if (soundEffect.ToString().Contains("Attack"))
            {
                IsVariant = true;
            }
            
            if (soundEffect == SoundEffect.Fanfare)
            {
                IsMusical = true;
            }

            clip = Resources.Load("Sounds/" + soundEffect.ToString()) as AudioClip;
        }
    }
}
