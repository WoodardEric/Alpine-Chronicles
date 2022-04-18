using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : AudioManager
{
    private readonly Dictionary<MusicTrack, AudioClip> tracks = new Dictionary<MusicTrack, AudioClip>();
    private float currentVolume;

    public static MusicManager Instance 
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
            Volume = 0.5f;
            Instance = this;
            ReadClips();
            DontDestroyOnLoad(this);
            Play(MusicTrack.Menu);
        }
    }


    public void Play(MusicTrack track)
    {
        var clip = tracks[track];
        if (audioSource.isPlaying)
        {
            StartCoroutine(TransitionTrack(clip));
        }
        else
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }


    protected override void ReadClips()
    {
        tracks.Add(MusicTrack.Menu, Resources.Load("Music/menu") as AudioClip);
        tracks.Add(MusicTrack.SceneOne, Resources.Load("Music/menu") as AudioClip);
        tracks.Add(MusicTrack.SceneTwo, Resources.Load("Music/menu") as AudioClip);
        tracks.Add(MusicTrack.SceneThree, Resources.Load("Music/menu") as AudioClip);
    }


    public void DuckMusic(float duration)
    {
        currentVolume = Volume;
        var targetVol =  0.0f;
        var fadeDur =  0.2f;
        StartCoroutine(Fade(fadeDur, targetVol));
        Invoke(nameof(ResetVolume), duration);
    }


    private void ResetVolume()
    {
        StartCoroutine(Fade(0.5f, currentVolume));
    }


    private IEnumerator TransitionTrack(AudioClip track)
    {
        StartCoroutine(Fade(0.5f, 0f));
        yield return new WaitForSeconds(0.48f);
        audioSource.Stop();
        audioSource.clip = track;
        audioSource.Play();
        StartCoroutine(Fade(0.5f, Volume));
    }


    private IEnumerator Fade(float dur, float vol)
    {
        float currentTime = 0;
        float startVol = Volume;
        while (currentTime < dur)
        {
            currentTime += Time.deltaTime;
            Volume = Mathf.Lerp(startVol, vol, currentTime / dur);
            yield return null;
        }
        yield break;
    }


    void Update()
    {

    }


    public enum MusicTrack
    {
        Menu,
        SceneOne,
        SceneTwo,
        SceneThree,
    }
}
