using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTwoFactory : ItemFactory
{
    public override ItemClass GetItemClass()
    {
        return new WeaponTwo();
    }
}