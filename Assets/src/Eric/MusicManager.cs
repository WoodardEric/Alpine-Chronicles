using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: AudioManager subclass that controls playing music tracks for the game.
* 
* Member Variables:
* tracks - a dictionary of all avialbe music tracks. Key is a MusicTrack enum that maps to a AudioClip value.
* currentVolume - The audiosources current volume that can be used to restore the volume after a temporary fade.
*/
public class MusicManager : AudioManager
{
    private readonly Dictionary<MusicTrack, AudioClip> tracks = new Dictionary<MusicTrack, AudioClip>();
    private float currentVolume;

    /*
    * Summary: Instance Property get and set the MusicManager instance for this singleton class.
    * 
    * Parameters:
    * MusicManager - the current instance of a MusicManger class
    * 
    * return:
    * MusicManger - returns the only allowed instance of a MusicManager class.
    */
    public static MusicManager Instance 
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
            Volume = 0.5f;
            Instance = this;
            ReadClips();
            DontDestroyOnLoad(this);
            Play(MusicTrack.Menu);
        }
    }


    /*
    * Summary: Start playing a new track. If a track is currently being played,
    * it will be faded out before the new track fades in
    * 
    * Parameters:
    * track - New music track that will be played.
    */
    public void Play(MusicTrack track)
    {
        var clip = tracks[track];

        if (clip == Source.clip)
        {
            return;
        }
        if (Source.isPlaying)
        {
            StartCoroutine(TransitionTrack(clip));
        }
        else
        {
            Source.clip = clip;
            Source.Play();
        }
    }


    /*
    * Summary: Reads music files from the Music folder in the resources directory as clips and
    * adds them to the tracks list.
    * 
    */
    protected override void ReadClips()
    {
        tracks.Add(MusicTrack.Menu, Resources.Load("Music/menu") as AudioClip);
        tracks.Add(MusicTrack.SceneOne, Resources.Load("Music/SceneOne") as AudioClip);
        tracks.Add(MusicTrack.SceneTwo, Resources.Load("Music/SceneTwo") as AudioClip);
        tracks.Add(MusicTrack.SceneThree, Resources.Load("Music/SceneThree") as AudioClip);
    }


    /*
    * Summary: fades the music out for a set duration before
    * fading back in
    * 
    * Parameters:
    * duration - The time in seconds to fade the music for. 
    */
    public void DuckMusic(float duration)
    {
        currentVolume = Volume;
        var targetVol =  0.0f;
        var fadeDur =  0.2f;
        StartCoroutine(Fade(fadeDur, targetVol));
        Invoke(nameof(ResetVolume), duration);
    }

    /*
    * Summary: fades the music out for a set duration before
    * fading back in
    */
    private void ResetVolume()
    {
        StartCoroutine(Fade(0.5f, currentVolume));
    }


    /*
    * Summary: Transitions the audio source to a new music track
    * 
    * Parameters:
    * tack - The audio clip to be played
    * 
    * Return:
    * IEnumerator -
    */
    private IEnumerator TransitionTrack(AudioClip track)
    {
        var currVolume  = Volume;
        StartCoroutine(Fade(0.5f, 0f));
        yield return new WaitForSeconds(0.48f);
        Source.Stop();
        Source.clip = track;
        Source.Play();
        StartCoroutine(Fade(0.5f, currVolume));
    }

    /*
    * Summary: Fades the audio track over a given amount of time.
    * 
    * Parameters:
    * dur - The length of time to perform the fade over.
    * vol - The target volume of for the fade.
    * 
    * Return:
    * IEnumerator -
    */
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


    /*
    * Summary: List of the avialbe music track that can be used in the game
    */
    public enum MusicTrack
    {
        Menu,
        SceneOne,
        SceneTwo,
        SceneThree,
    }
}
