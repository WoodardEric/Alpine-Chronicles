/*
 * Filename: Door.cs
 * Developer: Joseph
 * Purpose: Implement the IInteractable interface and provide a superclass for other doors
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: Define interact() and Open()
 */
public class Door : MonoBehaviour, IInteractable
{
    /*
     * Summary: Call Open() when interact() is called
     */
    public void interact()
    {
        Open();
        PlayerClass player = PlayerClass.Instance;
        player.IsInteracting(false);
    }

    /*
     * Summary: do nothing
     */
    public virtual void Open()
    {
        Debug.Log("The door appears to be locked.");
        SoundManager.Instance.Play(SoundManager.SoundEffect.LockedDoor);
    }
}