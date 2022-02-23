using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CoinPickup : MonoBehaviour
{

    public AudioSource sound;
    void OnTriggerEnter2D (Collider2D col){
        if(col.gameObject.name == "Player"){
            Debug.Log("Coin has been collected!");
            sound.Play();
            Destroy(this.gameObject);

        }


    }
}
