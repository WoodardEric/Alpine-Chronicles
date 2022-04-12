/*
* Filename: WeaponSixFactory.cs
* Developer: Sophia Sivula
* Purpose: This file implements the factory pattern for the WeaponSix
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: subclass of ItemFactory for WeaponSix, creating the factory pattern  
*/
public class WeaponSixFactory : ItemFactory
{
    /*
    * Summary: function to get the item class, WeaponSix
    * 
    * Returns:
    * WeaponSix() - returns a new WeaponSix when GetItemClass() is called
    */
    public override ItemClass GetItemClass()
    {
        return new WeaponSix();
    }
}