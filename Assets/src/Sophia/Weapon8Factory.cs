using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon8Factory : ItemFactory
{
    public override ItemClass GetItemClass()
    {
        return new Weapon8();
    }
}