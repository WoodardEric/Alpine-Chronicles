using NUnit.Framework;
using UnityEngine;

public class AudioTests
{
    GameObject gameObject;
    GameObject audioSource;
    AudioPlayer audioPlayer;

    [SetUp]
    public void Setup()
    {
        gameObject = new GameObject();
        audioPlayer = gameObject.AddComponent<AudioPlayer>();
        audioSource = new GameObject();
        //audioPlayer.audioSource = audioSource.AddComponent<AudioSource>();
    }

    [TearDown]
    public void TearDown()
    {
        GameObject.DestroyImmediate(audioPlayer);
        GameObject.DestroyImmediate(gameObject);
    }

    // A Test behaves as an ordinary method
    [Test]
    public void VolumeTest()
    {
        audioPlayer.SetVolume(1.0f);

        Assert.AreEqual(1.0f, audioPlayer.Volume);

        audioPlayer.SetVolume(0);

        Assert.AreEqual(0, audioPlayer.Volume);

        audioPlayer.SetVolume(0.3f);

        Assert.AreEqual(0.3f, audioPlayer.Volume);

        audioPlayer.SetVolume(2.5f);

        Assert.AreEqual(1.0f, audioPlayer.Volume);

        audioPlayer.SetVolume(-0.4f);

        Assert.AreEqual(0, audioPlayer.Volume);
    }

}
