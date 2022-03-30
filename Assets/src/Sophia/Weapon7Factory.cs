using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon7Factory : ItemFactory
{
    public override ItemClass GetItemClass()
    {
        return new Weapon7();
    }
}