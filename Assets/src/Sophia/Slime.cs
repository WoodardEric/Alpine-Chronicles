/*
* Filename: Slime.cs
* Developer: Sophia Sivula
* Purpose: This file applies attribute to the Slime
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: subclass of ItemClass for Slime
* Member Variables: 
* subItemName - a string that stores the item name
* subStrength - an integer that stores strength
* subHealth - an int that stores health
* subSpriteImage - a Sprite that stores the sprite image
* subTempStrength - an int that stores the temporary strength with inputs strength and duration
* subTempSpeed - an int that stores the temporary speed with inputs speed and duration
*/
public class Slime : ItemClass
{
    private readonly string subItemName;
    private int subStrength;
    private int subHealth;

    private Sprite subSpriteImage;
    private (int str, int len) subTempStrength;
    private (float spd, int len) subTempSpeed;

/*
* Summary: Assigns values to item variables, and sets sprite image
*/
    public Slime()
    {
        subItemName = "Slime";
        subStrength = -1;
        // error state, if the thing doesnt change it
        subHealth = -5; 
        subTempStrength = (-1, -1);
        //if speed, first number is increase by how much, and second is for how long in seconds
        subTempSpeed = (-1, -1); 
        subSpriteImage = Resources.Load<Sprite>("Items Pack/Pixel Art Icon Pack - RPG/Texture/Monster Part/Slime Gel.png");

    }

    public override string itemName
    {
        get {return subItemName;}
    }

    public override Sprite spriteImage
    {
        get {return subSpriteImage;}
    }
    public override int strength
    {
        get {return subStrength;}
    }
    public override int health
    {
        get {return subHealth;}
    }


    public override (int, int) tempStrength
    {
        get {return subTempStrength;}
    }

    public override (float, int) tempSpeed
    {
        get {return subTempSpeed;}
    }
}