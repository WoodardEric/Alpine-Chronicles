/*
* Filename: BossKeyFactory.cs
* Developer: Sophia Sivula
* Purpose: This file implements the factory pattern for the BossKey
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: subclass of ItemFactory for BossKey, creating the factory pattern  
*/
public class BossKeyFactory : ItemFactory
{
    /*
    * Summary: function to get the item class, BossKey
    * 
    * Returns:
    * BossKey() - returns a new BossKey when GetItemClass() is called
    */
    public override ItemClass GetItemClass()
    {
        return new BossKey();
    }
}