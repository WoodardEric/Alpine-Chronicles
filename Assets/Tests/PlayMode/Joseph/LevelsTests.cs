using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class LevelsTests
{
    [SetUp]
    public void setup()
    {
        SceneManager.LoadScene(0);
        SceneManager.LoadScene(1);
    }


    [UnityTest]
    public IEnumerator ChangeSceneToFrom()
    {
        //Get a hold of a LevelManager Instance;
        LevelManager LM = LevelManager.Instance;
        Assert.IsNotNull(LM);
        LM.test = true;

        LM.ChangeScene(1,2);
        yield return null;
        Assert.AreEqual(1,LM.goodScene);

        LM.ChangeScene(1,4);
        yield return null;
        Assert.AreEqual(0,LM.goodScene);
 
        LM.ChangeScene(1,0);
        yield return null;
        Assert.AreEqual(0,LM.goodScene);

        LM.ChangeScene(0,1);
        yield return null;
        Assert.AreEqual(0,LM.goodScene);

        LM.ChangeScene(4,2);
        yield return null;
        Assert.AreEqual(0,LM.goodScene);
    }

    [UnityTest]
    public IEnumerator UpdateLevels()
    {
        LevelManager LM = LevelManager.Instance;
        List<string> Fog;

        LM.UpdateLevel(0,"string");
        yield return null;
        Fog = LM.GetLevelFog(0);
        yield return null;
        Assert.IsNull(Fog);

        LM.UpdateLevel(1,"string");
        yield return null;
        Fog = LM.GetLevelFog(1);
        yield return null;
        Assert.AreEqual(1,Fog.Count);

        LM.UpdateLevel(1,"string");
        yield return null;
        Fog = LM.GetLevelFog(1);
        yield return null;
        Assert.AreEqual(1,Fog.Count);

        LM.UpdateLevel(2,"string");
        yield return null;
        Fog = LM.GetLevelFog(2);
        yield return null;
        Assert.AreEqual(1,Fog.Count);

        LM.UpdateLevel(2,"string");
        yield return null;
        Fog = LM.GetLevelFog(2);
        yield return null;
        Assert.AreEqual(1,Fog.Count);

        LM.UpdateLevel("string");
        yield return null;
        Fog = LM.GetKeyDoors();
        yield return null;
        Assert.AreEqual(1,Fog.Count);

        LM.UpdateLevel("string");
        yield return null;
        Fog = LM.GetKeyDoors();
        yield return null;
        Assert.AreEqual(1,Fog.Count);
    }
}