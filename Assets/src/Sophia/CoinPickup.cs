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
* semaphor - an int to track the semaphor for making sure the player doesn't hit two colliders
*/
public class CoinPickup : MonoBehaviour
{

    public GameObject sound;
    static int score = 0;
    static int maxScore = 100000;

    static int semaphor = 0;

    /*
    * Summary: Adjusts the player's score
    */
    public void AdjustScore()
    {
      if(score <= maxScore && score >= 0)
      {
            score = score + 50;
        }
        else if(score < 0)
        {
            score = 0;
        }
        else if(score > maxScore)
        {
            score = maxScore;
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
        // for Riley, to access when loading score
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
            if (++semaphor > 1)
            {
                semaphor = 0;
                return;
            }
            //SoundManager.Instance.Play(SoundManager.SoundEffect.Coin);            
            Debug.Log("Coin has been collected!");
            AdjustScore();
            SoundManager.Instance.Play(SoundManager.SoundEffect.Coin);
            Destroy(this.gameObject);
        }
    }

     /*
    * Summary: Sets the semaphor to 0 so more coins can be properly counted
    *
    * Parameters:
    * col - the player's Collider2D
    */
    void OnTriggerExit2D(Collider2D col)
    {
        semaphor = 0;
    }
}
