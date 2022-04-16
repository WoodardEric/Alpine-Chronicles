/*
 * Filename:  Rupee.cs
 * Developer: Riley Walsh
 * Purpose:   This file contains a class that creates strength for player when picking up a rupee.  
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* Summary: This Class is setting the player stats, once picking up the rupee.
*
* Member Variables:
* itemName- used to read in object name.
* subStrength - used to set player strength. 
*/
public abstract class Rupee : PrefabClass
{
    private readonly string itemName;
    private int subStrength;


    /*
     * Summary: gets the item called rupee, and sets strength to -1. 
     */
    public Rupee()
    {
        itemName = "Rupee";
        subStrength = -1;
    }


   /*
    * Summary: overrides string name, and returns it. 
    */
    public override string item
    {
        get { return itemName; }
    }


    /*
    * Summary: overrides strength and returns new strength. 
    */
    public override int strength
    {
        get { return subStrength; }
    }

}
