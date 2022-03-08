using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class passwordTest
{
    bool valid;
    // A Test behaves as an ordinary method
    [Test]
    public void passwordTestSimplePasses()
    {
        // Use the Assert class to test conditions
        GameObject obj = new GameObject();
        obj.AddComponent<PlayerClass>();
        drbcMode t = obj.AddComponent<drbcMode>();

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
