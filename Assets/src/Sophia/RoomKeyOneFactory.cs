/*
* Filename: RoomKeyOneFactory.cs
* Developer: Sophia Sivula
* Purpose: This file implements the factory pattern for the RoomKeyOne
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: subclass of ItemFactory for RoomKeyOne, creating the factory pattern  
*/
public class RoomKeyOneFactory : ItemFactory
{
     /*
    * Summary: function to get the item class, RoomKeyOne
    * 
    * Returns:
    * RoomKeyOne() - returns a new RoomKeyOne when GetItemClass() is called
    */
    public override ItemClass GetItemClass()
    {
        return new RoomKeyOne();
    }
}