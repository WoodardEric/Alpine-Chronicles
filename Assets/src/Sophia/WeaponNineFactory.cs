/*
* Filename: WeaponNineFactory.cs
* Developer: Sophia Sivula
* Purpose: This file implements the factory pattern for the WeaponNine
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: subclass of ItemFactory for WeaponNine, creating the factory pattern  
*/
public class WeaponNineFactory : ItemFactory
{
    /*
    * Summary: function to get the item class, WeaponNine
    * 
    * Returns:
    * WeaponNine() - returns a new WeaponNine when GetItemClass() is called
    */
    public override ItemClass GetItemClass()
    {
        return new WeaponNine();
    }
}