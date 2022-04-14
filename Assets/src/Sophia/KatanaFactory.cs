/*
* Filename: KatanaFactory.cs
* Developer: Sophia Sivula
* Purpose: This file implements the factory pattern for the Katana
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: subclass of ItemFactory for Katana, creating the factory pattern  
*/
public class KatanaFactory : ItemFactory
{
    /*
    * Summary: function to get the item class, Katana
    * 
    * Returns:
    * Katana() - returns a new Katana when GetItemClass() is called
    */
    public override ItemClass GetItemClass()
    {
        return new Katana();
    }

    /*
    * Summary: static function to display debug log
    */
    private void StaticDebug()
    {
        Debug.Log("Katana, static.");    
    }
}