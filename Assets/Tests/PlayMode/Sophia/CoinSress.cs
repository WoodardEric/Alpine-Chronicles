using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class CoinSress
{
    float contactTime;

    [SetUp]
    public void setup(){
        SceneManager.LoadScene("SophiaStressLevel");
        contactTime = 1f;
    }

    [UnityTest]
    public IEnumerator CoinSpeedStress()
    {
        StressPlayer player = StressPlayer.Instance;
        Vector3 pos = new Vector3(5.25f, 0f, 0f);

        Debug.Log("Initial player speed: " + player.moveSpeed);
        GameObject coin = null;//GameObject.Find("Coin");

    
        do 
        {
            if (coin == null)
            {
                coin = Object.Instantiate(Resources.Load("Coin"), pos, Quaternion.identity) as GameObject;
                float tempSpd = player.moveSpeed;
                player.moveSpeed = 0;
                yield return null;
                player.moveSpeed = tempSpd;
            }
            Debug.Log("Succeeds at speed: " + player.moveSpeed);
            player.setPlayerPos(new Vector2(0f, 0f));
            float currSpd = player.moveSpeed;
            currSpd *= 1.1f;
            player.moveSpeed = currSpd;

            contactTime /= 1.075f;
            yield return new WaitForSeconds(contactTime);
        } while (coin == null);

        Debug.Log("Failed collision at speed: " + player.moveSpeed);
        player.moveSpeed = 0f;
    }
}
