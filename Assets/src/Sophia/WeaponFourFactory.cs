using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFourFactory : ItemFactory
{
    public override ItemClass GetItemClass()
    {
        return new WeaponFour();
    }
}
