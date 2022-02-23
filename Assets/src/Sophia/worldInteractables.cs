using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldInteractables : MonoBehaviour, IInteractable
{
//    void OnTriggerEnter2D (Collider2D col)
//     {
//        if(col.gameObject.name == "Computer"){
//            Debug.Log("Player has interacted with the computer.");
//        }
//     }

    public void interact()
    {
        if(gameObject.name == "Computer"){
           Debug.Log("Player has interacted with the computer.");
       }
    }
}
