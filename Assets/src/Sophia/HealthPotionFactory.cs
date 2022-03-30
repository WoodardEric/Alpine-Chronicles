using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionFactory : ItemFactory
{
    public override ItemClass GetItemClass()
    {
        return new HealthPotion();
    }
}