/*
* Filename: PowerupPickup.cs
* Developer: Sophia Sivula
* Purpose: This file triggers when a when a powerup is picked up
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: class for picking up the powerups
*/
public class PowerupPickup : MonoBehaviour
{
    /*
    * Summary: Sets up the trigger collider for the player and a powerup
    *
    * Parameters:
    * col - the player's Collider2D
    */
    void OnTriggerEnter2D (Collider2D col){
        if(col.gameObject.name == "Player"){
            Debug.Log("Powerup has been collected!");
            //sound.SendMessage("PlaySound");
            Destroy(this.gameObject);

        }


    }
}
