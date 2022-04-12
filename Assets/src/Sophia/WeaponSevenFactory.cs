/*
* Filename: WeaponSevenFactory.cs
* Developer: Sophia Sivula
* Purpose: This file implements the factory pattern for the WeaponSeven
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: subclass of ItemFactory for WeaponSeven, creating the factory pattern  
*/
public class WeaponSevenFactory : ItemFactory
{
    /*
    * Summary: function to get the item class, WeaponSeven
    * 
    * Returns:
    * WeaponSeven() - returns a new WeaponSeven when GetItemClass() is called
    */
    public override ItemClass GetItemClass()
    {
        return new WeaponSeven();
    }
}