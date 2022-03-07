using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerSingletonTest
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator InstantiationTest()
    {
        // Create one instance of player
        GameObject player1 = new GameObject();
        player1.AddComponent<Rigidbody2D>();
        PlayerClass player = player1.AddComponent<PlayerClass>();

        // Skip frame
        yield return null;

        // Attempt to create a second instance of player
        GameObject player2 = new GameObject();
        player2.AddComponent<Rigidbody2D>();
        PlayerClass secondInstance = player2.AddComponent<PlayerClass>();


        // Skip a frame
        yield return null;
        
        // Test whether first player was instantiated
        Assert.IsNotNull(player1);
        // Test whether second player was instantiated
        Assert.IsTrue(player2 == null);
    }
}
