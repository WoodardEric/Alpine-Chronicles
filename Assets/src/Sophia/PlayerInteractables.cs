using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractables : MonoBehaviour
{
   void OnTriggerEnter2D (Collider2D col)
    {
       if(col.gameObject.name == "Computer"){
           Debug.Log("Player has interacted with the computer.");
       }
    }
}
