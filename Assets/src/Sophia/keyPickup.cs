/*
* Filename: KeyPickup.cs
* Developer: Sophia Sivula
* Purpose: This file triggers when a key is picked up
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: class for picking up the keys
*/
public class KeyPickup : MonoBehaviour
{
    /*
    * Summary: Sets up the trigger collider for the player and a key
    *
    * Parameters:
    * col - the player's Collider2D
    */
   void OnTriggerEnter2D (Collider2D col){
        if(col.gameObject.name == "Player"){
            Debug.Log("Key has been collected!");
            //sound.SendMessage("PlaySound");
            Destroy(this.gameObject);

        }


    }
}
