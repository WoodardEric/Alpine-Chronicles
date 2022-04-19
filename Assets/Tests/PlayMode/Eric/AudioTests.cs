using NUnit.Framework;
using UnityEngine;


public class AudioTests
{
    GameObject gameObject;
    MusicManager musicManager;
    GameObject soundObject;
    SoundManager soundManager;

    [SetUp]
    public void Setup()
    {
        gameObject = new GameObject();
        musicManager = gameObject.AddComponent<MusicManager>();
        musicManager.Awake();

        soundObject = new GameObject();
        soundManager = soundObject.AddComponent<SoundManager>();
        soundManager.Awake();
    }

    [TearDown]
    public void TearDown()
    {
        GameObject.DestroyImmediate(musicManager);
        GameObject.DestroyImmediate(gameObject);
    }

    // A Test behaves as an ordinary method
    [Test]
    public void AudioManagerTest()
    {
        musicManager.SetVolume(1.0f);
        Assert.AreEqual(1.0f, musicManager.Volume);

        musicManager.SetVolume(0);
        Assert.AreEqual(0, musicManager.Volume);

        musicManager.SetVolume(0.3f);
        Assert.AreEqual(0.3f, musicManager.Volume);

        musicManager.SetVolume(2.5f);
        Assert.AreEqual(1.0f, musicManager.Volume);

        musicManager.SetVolume(-0.4f);
        Assert.AreEqual(0, musicManager.Volume);

        musicManager.Mute();
        Assert.IsTrue(musicManager.Source.mute);

        musicManager.Mute();
        Assert.IsFalse(musicManager.Source.mute);
    }

    [Test]
    public void MusicManagerTests()
    {
        musicManager.Play(MusicManager.MusicTrack.Menu);
        var currentVol = musicManager.Volume;
        musicManager.Play(MusicManager.MusicTrack.SceneOne);
        Assert.AreEqual(currentVol, musicManager.Volume);
        Assert.AreEqual("SceneOne", musicManager.Source.clip.name);
    }
}
