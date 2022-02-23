using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D col){
        if(col.gameObject.name == "Player"){
            Debug.Log("Coin has been collected!");
            Destroy(this.gameObject);
        }

    }
}
