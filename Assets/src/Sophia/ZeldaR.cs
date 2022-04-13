using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeldaR : ItemClass
{
    private readonly string subItemName;
    private int subStrength;
    private int subHealth;

    private Sprite subSpriteImage;
    private (int str, int len) subTempStrength;
    private (int spd, int len) subTempSpeed;

    /*
    * Summary: Assigns values to item variables, and sets sprite image
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
