using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon6Factory : ItemFactory
{
    public override ItemClass GetItemClass()
    {
        return new Weapon6();
    }
}