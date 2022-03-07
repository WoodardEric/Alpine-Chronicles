using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using System.Threading;

public class StressRiley
{
    // A Test behaves as an ordinary method
    [Test]
    public void StressRileySimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator StressRileyWithEnumeratorPasses()
    {
        while (true)
        {
            Debug.Log("forever printing");
            Thread.Sleep(5000);
        }
        yield return null;
    }
}
