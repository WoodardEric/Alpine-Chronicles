/*
* Filename: WeaponFiveFactory.cs
* Developer: Sophia Sivula
* Purpose: This file implements the factory pattern for the WeaponFive
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: subclass of ItemFactory for WeaponFive, creating the factory pattern  
*/
public class WeaponFiveFactory : ItemFactory
{
    /*
    * Summary: function to get the item class, WeaponFive
    * 
    * Returns:
    * WeaponFive() - returns a new WeaponFive when GetItemClass() is called
    */
    public override ItemClass GetItemClass()
    {
        return new WeaponFive();
    }
}