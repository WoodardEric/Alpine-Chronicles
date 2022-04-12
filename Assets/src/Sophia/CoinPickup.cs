using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CoinPickup : MonoBehaviour
{

    public GameObject sound;
    static int score = 0;
    static int maxScore = 100000;

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

    public static int GetScore(){
        return score;
    }

    public static void SetScore(int change){
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
