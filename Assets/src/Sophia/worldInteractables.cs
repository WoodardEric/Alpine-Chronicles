/*
* Filename: IInteractables.cs
* Developer: Sophia Sivula
* Purpose: This file WorldInteractables creates an interface for interactables placed in the world
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: Creates an interact function for other members in the group to call when an object needs to interact
*/
public class WorldInteractables : MonoBehaviour, IInteractable
{
    public void interact()
    {
        if(gameObject.name == "Computer"){
           Debug.Log("Player has interacted with the computer.");
       }
    }
}
