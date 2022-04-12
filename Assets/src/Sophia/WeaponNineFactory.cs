using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponNineFactory : ItemFactory
{
    public override ItemClass GetItemClass()
    {
        return new WeaponNine();
    }
}