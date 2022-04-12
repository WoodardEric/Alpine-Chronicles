using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponThreeFactory : ItemFactory
{
    public override ItemClass GetItemClass()
    {
        return new WeaponThree();
    }
}
