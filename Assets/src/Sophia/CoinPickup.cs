/*
* Filename: CoinPickup.cs
* Developer: Sophia Sivula
* Purpose: This file adjusts/sets player score when a coin is picked up
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* Summary: class for picking up the coins and tracking score
* Member Variables: 
* sound - GameObject that attaches a sound to when a coin is picked up 
* score - an int that stores the player score
* maxScore - an int that stores the maximum score the player can reach
*/
public class CoinPickup : MonoBehaviour
{

    public GameObject sound;
    static int score = 0;
    static int maxScore = 100000;

    /*
    * Summary: Adjusts the player's score
    */
    public void AdjustScore()
    {
      if(score <= maxScore)
      {
            score = score + 50;
        }
        else
        {
            score = 500;
        }  

    }

    /*
    * Summary: Gets the player score
    *
    * Returns:
    * Score - the int that stores the score
    */
    public static int GetScore(){
        return score;
    }

    /*
    * Summary: Sets the player score, makes sure it is within range of 0 - 100,000
    *
    * Parameters:
    * change - an int passed in that is the last saved score
    */
    public static void SetScore(int change)
    {
        if(change < 0)
        {
            score = 0;
        }
        if(change >= maxScore)
        {
            score = maxScore;
        }
        else
        {
            score = change;
        }
    }

    /*
    * Summary: Sets up the trigger collider for the player and a coin
    *
    * Parameters:
    * col - the player's Collider2D
    */
    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.gameObject.name == "Player")
        {
            Debug.Log("Coin has been collected!");
            AdjustScore();
            //sound.SendMessage("PlaySound");
            Destroy(this.gameObject);
        }
    }
}
