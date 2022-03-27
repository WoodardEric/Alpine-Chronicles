using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyPickup : MonoBehaviour
{
   void OnTriggerEnter2D (Collider2D col){
        if(col.gameObject.name == "Player"){
            Debug.Log("Key has been collected!");
            //sound.SendMessage("PlaySound");
            Destroy(this.gameObject);

        }


    }
}
