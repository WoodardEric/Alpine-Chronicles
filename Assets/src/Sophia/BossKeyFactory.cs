using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKeyFactory : ItemFactory
{
    public override ItemClass GetItemClass()
    {
        return new BossKey();
    }
}