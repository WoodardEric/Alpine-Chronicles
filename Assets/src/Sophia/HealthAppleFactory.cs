/*
* Filename: HealthAppleFactory.cs
* Developer: Sophia Sivula
* Purpose: This file implements the factory pattern for the HealthApple
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: subclass of ItemFactory for HealthApple, creating the factory pattern  
*/
public class HealthAppleFactory : ItemFactory
{
    /*
    * Summary: function to get the item class, HealthApple
    * 
    * Returns:
    * HealthApple() - returns a new HealthApple when GetItemClass() is called
    */
    public override ItemClass GetItemClass()
    {
        return new HealthApple();
    }
}