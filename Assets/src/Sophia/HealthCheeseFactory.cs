/*
* Filename: HealthCheeseFactory.cs
* Developer: Sophia Sivula
* Purpose: This file implements the factory pattern for the HealthCheese
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCheeseFactory : ItemFactory
{
    /*
    * Summary: function to get the item class, HealthCheese
    * 
    * Returns:
    * HealthCheese() - returns a new HealthCheese when GetItemClass() is called
    */
    public override ItemClass GetItemClass()
    {
        return new HealthCheese();
    }
}