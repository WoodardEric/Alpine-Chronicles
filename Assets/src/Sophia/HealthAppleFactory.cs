using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAppleFactory : ItemFactory
{
    public override ItemClass GetItemClass()
    {
        return new HealthApple();
    }
}