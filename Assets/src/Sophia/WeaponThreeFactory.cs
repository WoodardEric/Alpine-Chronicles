/*
* Filename: WeaponThreeFactory.cs
* Developer: Sophia Sivula
* Purpose: This file implements the factory pattern for the WeaponThree
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: subclass of ItemFactory for WeaponThree, creating the factory pattern  
*/
public class WeaponThreeFactory : ItemFactory
{
    /*
    * Summary: function to get the item class, WeaponThree
    * 
    * Returns:
    * WeaponThree() - returns a new WeaponThree when GetItemClass() is called
    */
    public override ItemClass GetItemClass()
    {
        return new WeaponThree();
    }
}
