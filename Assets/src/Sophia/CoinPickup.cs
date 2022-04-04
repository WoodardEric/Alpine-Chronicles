using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CoinPickup : MonoBehaviour
{

    public GameObject sound;
    public static int score = 0;

    public void AdjustScore(){
      if(score <= 450){
            score = score + 50;
        }
        else{
            score = 500;
        }  

    }

    public static int GetScore(){
        return score;
    }

    public void SetScore(int change){
        score = change;
    }
    void OnTriggerEnter2D (Collider2D col){
        if(col.gameObject.name == "Player"){
            Debug.Log("Coin has been collected!");
            AdjustScore();
            //sound.SendMessage("PlaySound");
            Destroy(this.gameObject);

        }


    }
}
