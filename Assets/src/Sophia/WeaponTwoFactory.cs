/*
* Filename: WeaponTwoFactory.cs
* Developer: Sophia Sivula
* Purpose: This file implements the factory pattern for the WeaponTwo
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: subclass of ItemFactory for WeaponTwo, creating the factory pattern  
*/
public class WeaponTwoFactory : ItemFactory
{
    /*
    * Summary: function to get the item class, WeaponTwo
    * 
    * Returns:
    * WeaponTwo() - returns a new WeaponTwo when GetItemClass() is called
    */
    public override ItemClass GetItemClass()
    {
        return new WeaponTwo();
    }
}