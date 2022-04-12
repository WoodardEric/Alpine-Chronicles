/*
* Filename: IInteractables.cs
* Developer: Sophia Sivula
* Purpose: This file IInteractable creates an interface for item interactables placed in the world
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: Creates an interact function for other members in the group to call when an object needs to interact
*/
public interface IInteractable
{
    void interact();
}