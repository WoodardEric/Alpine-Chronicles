using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon9Factory : ItemFactory
{
    public override ItemClass GetItemClass()
    {
        return new Weapon9();
    }
}