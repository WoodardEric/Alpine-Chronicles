using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSixFactory : ItemFactory
{
    public override ItemClass GetItemClass()
    {
        return new WeaponSix();
    }
}