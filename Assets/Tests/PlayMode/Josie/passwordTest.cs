using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class passwordTest
{
    bool valid;
    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator passwordTestSimplePasses()
    {
        SceneManager.LoadScene("PassTestScene");
        // Use the Assert class to test conditions
        GameObject obj = new GameObject();
        //obj.AddComponent<PlayerClass>();
        drbcMode t = obj.AddComponent<drbcMode>();

        yield return null;

        valid = t.readStringInput("s");
        Assert.IsTrue(valid);

        valid = t.readStringInput("");
        Assert.IsFalse(valid);

        valid = t.readStringInput("123456789");
        Assert.IsTrue(valid);

        valid = t.readStringInput("0123456789");
        Assert.IsTrue(valid);

        valid = t.readStringInput("00123456789");
        Assert.IsFalse(valid);
    }

}
