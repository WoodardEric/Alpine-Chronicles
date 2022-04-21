/*
* Filename: ItemClass.cs
* Developer: Sophia Sivula
* Purpose: This file creates the attributes for each item within the ItemClass
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: class for items, includes virual 
* Member Variables: 
* itemName - a string that stores the item name
* strength - an integer that stores strength
* health - an int that stores health
* spriteImage - a Sprite that stores the sprite image
* tempStrength - an int that stores the temporary strength with inputs strength and duration
* tempSpeed - an int that stores the temporary speed with inputs speed and duration
*/
public class ItemClass
{
    public virtual string itemName{get;}
    public virtual int strength{get;}
    public virtual int health{get;}

    public virtual Sprite spriteImage{get;}
    public virtual (int str, int len)tempStrength{get;}
    public virtual (int spd, int len)tempSpeed{get;}

    public ItemClass()
    {
        itemName = "BaseItem";
        strength = -1;
        // error state, if the thing doesnt change it
        health = -1; 
        tempStrength = (-1, -1);
        //if speed, first number is increase by how much, and second is for how long in seconds
        tempSpeed = (-1, -1); 
        spriteImage = null;

    }
}