/*
* Filename: WeaponPickup.cs
* Developer: Sophia Sivula
* Purpose: This file triggers when a weapon is picked up
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: class for picking up the weapons
*/
public class WeaponPickup : MonoBehaviour
{
    /*
    * Summary: Sets up the trigger collider for the player and a weapon
    *
    * Parameters:
    * col - the player's Collider2D
    */
   void OnTriggerEnter2D (Collider2D col){
        if(col.gameObject.name == "Player"){
            Debug.Log("Weapon has been collected!");
            SoundManager.Instance.Play(SoundManager.SoundEffect.Fanfare);
            Destroy(this.gameObject);

        }
    }
}
