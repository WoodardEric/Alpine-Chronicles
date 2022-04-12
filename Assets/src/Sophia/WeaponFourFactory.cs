/*
* Filename: WeaponFourFactory.cs
* Developer: Sophia Sivula
* Purpose: This file implements the factory pattern for the WeaponFour
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: subclass of ItemFactory for WeaponFour, creating the factory pattern  
*/
public class WeaponFourFactory : ItemFactory
{
    /*
    * Summary: function to get the item class, WeaponFour
    * 
    * Returns:
    * WeaponFour() - returns a new WeaponFour when GetItemClass() is called
    */
    public override ItemClass GetItemClass()
    {
        return new WeaponFour();
    }
}
