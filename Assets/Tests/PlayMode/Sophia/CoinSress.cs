using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class CoinSress
{
    // A Test behaves as an ordinary method
    

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator CoinSressWithEnumeratorPasses()
    {
         SceneManager.LoadScene("SophiaStressLevel");
         List<GameObject> list = new List<GameObject>();
         int count = 0;
        while(true){
            
            list.Add(GameObject.Instantiate(Resources.Load("Coin")) as GameObject);
            Debug.Log("Number of objects spawned: " + (++count));
            yield return null;
        }
        
        
    }
}
