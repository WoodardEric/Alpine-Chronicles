/*
* Filename: ItemFactory.cs
* Developer: Sophia Sivula
* Purpose: This file implements the factory pattern for the ItemClass
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: subclass of ItemFactory for the ItemClass, creating the factory pattern  
*/
public class ItemFactory
{
    public virtual ItemClass GetItemClass()
    {
        return new ItemClass();
    }

    /*
    * Summary: static function to display debug log
    */
    private void StaticDebug()
    {
        Debug.Log("ItemFactory, static.");    
    }
}