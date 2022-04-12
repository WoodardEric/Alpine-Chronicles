/*
* Filename: SlimeFactory.cs
* Developer: Sophia Sivula
* Purpose: This file implements the factory pattern for the Slime
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: subclass of ItemFactory for Slime, creating the factory pattern  
*/
public class SlimeFactory : ItemFactory
{
    /*
    * Summary: function to get the item class, Slime
    * 
    * Returns:
    * Slime() - returns a new Slime when GetItemClass() is called
    */
    public override ItemClass GetItemClass()
    {
        return new Slime();
    }
}