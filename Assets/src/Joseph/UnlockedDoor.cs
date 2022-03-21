/*
 * Filename: UnlockedDoor.cs
 * Developer: Joseph
 * Purpose: "Open" this door
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: set this GameObject to false
 */
public class UnlockedDoor : Door
{
    /*
     * Summary: set the GameObject that this script is attached to to false
     */
    override public void Open()
    {
        Debug.Log("Open the door");
        //Destroy(this);
        //Still keeps the Door in the heirarchy
        this.gameObject.SetActive(false);
    }
}
