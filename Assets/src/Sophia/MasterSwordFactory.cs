/*
* Filename: MasterSwordFactory.cs
* Developer: Sophia Sivula
* Purpose: This file implements the factory pattern for the MasterSword
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: subclass of ItemFactory for MasterSword, creating the factory pattern  
*/
public class MasterSwordFactory : ItemFactory
{
    /*
    * Summary: function to get the item class, MasterSword
    * 
    * Returns:
    * MasterSword() - returns a new MasterSword when GetItemClass() is called
    */
    public override ItemClass GetItemClass()
    {
        return new MasterSword();
    }
}