using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeFactory : ItemFactory
{
    public override ItemClass GetItemClass()
    {
        return new Slime();
    }
}