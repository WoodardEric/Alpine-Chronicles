using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFiveFactory : ItemFactory
{
    public override ItemClass GetItemClass()
    {
        return new WeaponFive();
    }
}