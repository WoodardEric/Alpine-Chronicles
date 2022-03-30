using System.Collections.Generic;
using UnityEngine;

public class MusicManager : AudioManager
{
    private readonly Dictionary<MusicTrack, AudioClip> tracks = new Dictionary<MusicTrack, AudioClip>();

    public static MusicManager Instance { get; private set; }

    protected override void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            Volume = 0.5f;
            Instance = this;
            ReadClips();
            DontDestroyOnLoad(this);
            Play(MusicTrack.menu);
        }
    }


    public void Play(MusicTrack track)
    {
        audioSource.clip = tracks[track];
        audioSource.Play();
    }


    protected override void ReadClips()
    {
        tracks.Add(MusicTrack.menu, Resources.Load("Music/menu") as AudioClip);
    }


    void Update()
    {
        
    }


    public enum MusicTrack
    {
        menu
    }
}
