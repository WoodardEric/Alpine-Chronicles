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

        LM.ChangeScene(1,3);
        yield return null;
        Assert.AreEqual(0,LM.goodScene);
 
        LM.ChangeScene(1,0);
        yield return null;
        Assert.AreEqual(0,LM.goodScene);

        LM.ChangeScene(0,1);
        yield return null;
        Assert.AreEqual(0,LM.goodScene);

        LM.ChangeScene(3,2);
        yield return null;
        Assert.AreEqual(0,LM.goodScene);
    }
}