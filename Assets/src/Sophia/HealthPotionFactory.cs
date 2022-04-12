/*
* Filename: HealthPotionFactory.cs
* Developer: Sophia Sivula
* Purpose: This file implements the factory pattern for the HealthPotion
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: subclass of ItemFactory for HealthPotion, creating the factory pattern  
*/
public class HealthPotionFactory : ItemFactory
{
    /*
    * Summary: function to get the item class, HealthPotion
    * 
    * Returns:
    * HealthPotion() - returns a new HealthPotion when GetItemClass() is called
    */
    public override ItemClass GetItemClass()
    {
        return new HealthPotion();
    }
}