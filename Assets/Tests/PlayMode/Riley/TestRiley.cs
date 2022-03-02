using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestRiley
{
    
    [UnityTest]
    public IEnumerator TestRileyWithEnumeratorPasses()
    {
        
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        //add auto saving for 3 seconds here
        //use load to prove file has been created. 
        //for stress test loop save a million times until you crash. 
        yield return null;
    }
}
