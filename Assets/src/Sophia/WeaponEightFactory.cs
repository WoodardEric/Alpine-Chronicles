using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEightFactory : ItemFactory
{
    public override ItemClass GetItemClass()
    {
        return new WeaponEight();
    }
}