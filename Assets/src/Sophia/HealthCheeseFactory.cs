using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCheeseFactory : ItemFactory
{
    public override ItemClass GetItemClass()
    {
        return new HealthCheese();
    }
}