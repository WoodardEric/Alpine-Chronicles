/*
* Filename: StrengthPotionFactory.cs
* Developer: Sophia Sivula
* Purpose: This file implements the factory pattern for the StrengthPotion
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: subclass of ItemFactory for StrengthPotion, creating the factory pattern  
*/
public class StrengthPotionFactory : ItemFactory
{
     /*
    * Summary: function to get the item class, StrengthPotion
    * 
    * Returns:
    * StrengthPotion() - returns a new StrengthPotion when GetItemClass() is called
    */
    public override ItemClass GetItemClass()
    {
        return new StrengthPotion();
    }
}