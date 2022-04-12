/*
* Filename: SpeedPotionFactory.cs
* Developer: Sophia Sivula
* Purpose: This file implements the factory pattern for the SpeedPotion
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: subclass of ItemFactory for SpeedPotion, creating the factory pattern  
*/
public class SpeedPotionFactory : ItemFactory
{
    /*
    * Summary: function to get the item class, BossKey
    * 
    * Returns:
    * SpeedPotion() - returns a new SpeedPotion when GetItemClass() is called
    */
    public override ItemClass GetItemClass()
    {
        return new SpeedPotion();
    }
}