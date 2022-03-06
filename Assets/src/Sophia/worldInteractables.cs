using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldInteractables : MonoBehaviour, IInteractable
{
    public void interact()
    {
        if(gameObject.name == "Computer"){
           Debug.Log("Player has interacted with the computer.");
       }
    }
}
