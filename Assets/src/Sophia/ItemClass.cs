using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemClass
{
    public abstract string itemName{get;}
    public abstract int strength{get;}
    public abstract int health{get;}

    public abstract Sprite spriteImage{get;}
    public abstract (int str, int len)tempStrength{get;}
    public abstract (int spd, int len)tempSpeed{get;}
}
