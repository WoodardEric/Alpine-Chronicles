/*
 * Filename: FogDoor.cs
 * Developer: Joseph
 * Purpose: Functionality of FogDoors
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: Set the fog and door to false
 *
 * Member Variables:
 * fog - GameObject provided to become false
 */
public class FogDoor : Door
{
    public GameObject fog;

    /*
     * Summary: Set this object and fog to false
     */
    override public void Open()
    {
	    //Remove associated fog
        Debug.Log("Remove Fog");
        fog.SetActive(false);
        //Open the Door
        this.gameObject.SetActive(false);
    }
}