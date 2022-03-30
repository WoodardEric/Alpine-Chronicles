using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon4 : ItemClass
{
    private readonly string subItemName;
    private int subStrength;
    private int subHealh;

    private Sprite subSpriteImage;
    private (int str, int len) subTempStrength;
    private (int spd, int len) subTempSpeed;

    public Weapon4()
    {
        subItemName = "Weapon4";
        subStrength = 3;
        subHealh = -1; // error state, if the thing doesnt change it
        subTempStrength = (-1, -1);
        subTempSpeed = (-1, -1); //if speed, first number is increase by how much, and second is for how long in seconds
        subSpriteImage = Resources.Load<Sprite>("Items Pack/Pixel Art Icon Pack - RPG/Texture/Weapon & Tool/Silver Sword.png");

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
        get {return subHealh;}
    }


    public override (int, int) tempStrength
    {
        get {return subTempStrength;}
    }

    public override (int, int) tempSpeed
    {
        get {return subTempSpeed;}
    }
}