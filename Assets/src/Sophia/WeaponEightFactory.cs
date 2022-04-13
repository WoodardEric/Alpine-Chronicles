/*
* Filename: WeaponEightFactory.cs
* Developer: Sophia Sivula
* Purpose: This file implements the factory pattern for the WeaponEightFactory
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: subclass of ItemFactory for WeaponEight, creating the factory pattern  
*/

public class WeaponEightFactory : ItemFactory
{
    /*
    * Summary: function to get the item class, WeaponEight
    * 
    * Returns:
    * WeaponEight() - returns a new WeaponEight when GetItemClass() is called
    */
    public override ItemClass GetItemClass()
    {
        return new WeaponEight();
    }
}