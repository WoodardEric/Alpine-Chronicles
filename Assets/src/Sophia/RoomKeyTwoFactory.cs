/*
* Filename: RoomKeyTwoFactory.cs
* Developer: Sophia Sivula
* Purpose: This file implements the factory pattern for the RoomKeyTwo
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: subclass of ItemFactory for RoomKeyTwo, creating the factory pattern  
*/
public class RoomKeyTwoFactory : ItemFactory
{
    /*
    * Summary: function to get the item class, RoomKeyTwo
    * 
    * Returns:
    * RoomKeyTwo() - returns a new RoomKeyTwo when GetItemClass() is called
    */
    public override ItemClass GetItemClass()
    {
        return new RoomKeyTwo();
    }
}