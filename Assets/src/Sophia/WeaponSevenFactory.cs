using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSevenFactory : ItemFactory
{
    public override ItemClass GetItemClass()
    {
        return new WeaponSeven();
    }
}