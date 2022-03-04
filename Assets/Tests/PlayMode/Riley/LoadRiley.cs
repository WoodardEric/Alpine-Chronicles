using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadRiley
{
   
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest, Order(2)]
    public IEnumerator LoadRileyWithEnumeratorPasses()
    {
        bool exist;
        string loc = Application.persistentDataPath + "/test.ap";

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(loc, FileMode.Open);

        //Open Player/game data here//

        stream.Close();

        if (System.IO.File.Exists(loc))
        {
            Debug.Log("File Read...");
            exist = true;
        }

        else
        {
            exist = false;
            Debug.Log("File does not exist in the current directory!");
        }

        yield return new WaitForSeconds(2f);
    }
}
