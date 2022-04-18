using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SoundManager : AudioManager
{
    private readonly Dictionary<SoundEffect, Sound> clips = new Dictionary<SoundEffect, Sound>();


    public static SoundManager Instance 
    { 
        get; 
        private set; 
    }


    protected override void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            Volume = 0.4f;
            Instance = this;
            ReadClips();
            DontDestroyOnLoad(this);
        }
    }


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
        audioSource.PlayOneShot(clip);
    }


    protected override void ReadClips()
    {
        foreach (SoundEffect effect in Enum.GetValues(typeof(SoundEffect)))
        {
            clips.Add(effect, new Sound(effect));
        }
    }


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


    private class Sound
    {
        public AudioClip clip;
        public bool IsVariant = false;
        public bool IsMusical = false;

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
