using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class PlayerMovementStress
{
    float contactTime;

    [SetUp]
    public void setup(){
        SceneManager.LoadScene("TobyStressScene");
        contactTime = 1.5f;
    }

    [UnityTest]
    public IEnumerator playerSpeedStress()
    {
        GameObject wall = GameObject.Find("rightWall");

        StressPlayer player = StressPlayer.Instance;

        Debug.Log("Initial player speed: " + player.moveSpeed);
    
        while (player.transform.position.x < wall.transform.position.x)
        {
            Debug.Log("Succeeds at speed: " + player.moveSpeed);
            player.setPlayerPos(new Vector2(0f, 0f));
            float currSpd = player.moveSpeed;
            currSpd *= 1.1f;
            player.moveSpeed = currSpd;

            contactTime /= 1.075f;
            yield return new WaitForSeconds(contactTime);
        }

        Debug.Log("Failed collision at speed: " + player.moveSpeed);
        player.moveSpeed = 0f;
    }
}
