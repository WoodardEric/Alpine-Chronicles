using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CoinBoundary
{
     
    // A Test behaves as an ordinary method
    [Test]
    public void CoinBoundarySimplePasses()
    {
        GameObject obj = new GameObject();
        // Use the Assert class to test conditions
        //GameObject.Instantiate(Resources.Load("Coin")) as GameObject;
         CoinPickup coin = obj.AddComponent<CoinPickup>();
         coin.SetScore(499);
         coin.AdjustScore();
         Assert.AreEqual(500, CoinPickup.GetScore());

         coin.SetScore(500);
         coin.AdjustScore();
         Assert.AreEqual(500, CoinPickup.GetScore());

         coin.SetScore(501);
         coin.AdjustScore();
         Assert.AreEqual(500, CoinPickup.GetScore());
        
            
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    
}
