using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon3Factory : ItemFactory
{
    public override ItemClass GetItemClass()
    {
        return new Weapon3();
    }
}
