/*
 * Filename:  ZeldaR.cs
 * Developer: Riley Walsh
 * Purpose:   This file creates factor pattern for the ZeldaRupee. 
 */
 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* Summary: subclass of ItemFactory for ZeldaRupee, creating the factory pattern  
*/
public class ZeldaRFactory : ItemFactory
{

    /*
    * Summary: function to get the item class, WeaponSeven
    * 
    * Returns:
    * ZeldaR() - returns a new ZeldaR when GetItemClass() is called
    */
    public override ItemClass GetItemClass()
    {
        return new ZeldaR();
    }
}
