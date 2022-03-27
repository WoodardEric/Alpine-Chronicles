/*
 * Filename: StairDoor.cs
 * Developer: Joseph
 * Purpose: Change between areas in a scene
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: Change between areas in a scene
 *
 * Member Variables:
 * newX - floating point of the new X coordinate
 * newY - floating point of the new Y coordinate
 */
public class StairDoor : Door
{
    public float newX;
    public float newY;

    /*
     * Summary: Change between areas in a scene
     */
    override public void Open()
    {
	    PlayerClass player = PlayerClass.Instance;
        Vector2 newPosition = new Vector2(newX,newY);
        Debug.Log("Teleporting Player");
        player.SetPlayerPos(newPosition);
    }
}