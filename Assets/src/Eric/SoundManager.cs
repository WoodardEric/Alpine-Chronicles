using System.Collections.Generic;
using UnityEngine;

public class SoundManager : AudioManager
{
    public static SoundManager Instance { get; private set; }

    private readonly Dictionary<SoundEffect, AudioClip> clips = new Dictionary<SoundEffect, AudioClip>();

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
        audioSource.PlayOneShot(clips[soundEffect]);
    }

    protected override void ReadClips()
    {
        clips.Add(SoundEffect.Coin, Resources.Load("Sounds/coin") as AudioClip);
    }

    public enum SoundEffect
    {
        Coin
    }
}
