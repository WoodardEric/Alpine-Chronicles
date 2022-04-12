/*
* Filename: ItemClass.cs
* Developer: Sophia Sivula
* Purpose: This file creates the attributes for each item within the ItemClass
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: class for items
* Member Variables: 
* itemName - a string that stores the item name
* strength - an integer that stores strength
* health - an int that stores health
* spriteImage - a Sprite that stores the sprite image
* tempStrength - an int that stores the temporary strength with inputs strength and duration
* tempSpeed - an int that stores the temporary speed with inputs speed and duration
*/
public abstract class ItemClass
{
    public abstract string itemName{get;}
    public abstract int strength{get;}
    public abstract int health{get;}

    public abstract Sprite spriteImage{get;}
    public abstract (int str, int len)tempStrength{get;}
    public abstract (int spd, int len)tempSpeed{get;}
}
