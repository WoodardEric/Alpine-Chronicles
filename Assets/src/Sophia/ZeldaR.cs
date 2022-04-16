/*
 * Filename:  ZeldaR.cs
 * Developer: Riley Walsh
 * Purpose:   This file contains a class that redifines player stats through the itemClass script. 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* Summary: subclass of ItemClass for ZeldaRupee
* Member Variables: 
* subItemName - a string that stores the item name
* subStrength - an integer that stores strength
* subHealth - an int that stores health
* subSpriteImage - a Sprite that stores the sprite image
* subTempStrength - an int that stores the temporary strength with inputs strength and duration
* subTempSpeed - an int that stores the temporary speed with inputs speed and duration
*/


public class ZeldaR : ItemClass
{
    private readonly string subItemName;
    private int subStrength;
    private int subHealth;

    private Sprite subSpriteImage;
    private (int str, int len) subTempStrength;
    private (int spd, int len) subTempSpeed;
     

    /*
    * Summary: Assigns empty values to item variables, used as an example only.
    */
    public ZeldaR()
    {
        subItemName = "Rupee";
      
    }

    public override string itemName
    {
        get { return subItemName; }
    }


    public override Sprite spriteImage
    {
        get { return subSpriteImage; }
    }

    public override int strength
    {
        get { return subStrength; }
    }

    public override int health
    {
        get { return subHealth; }
    }


    public override (int, int) tempStrength
    {
        get { return subTempStrength; }
    }


    public override (int, int) tempSpeed
    {
        get { return subTempSpeed; }
    }
}
