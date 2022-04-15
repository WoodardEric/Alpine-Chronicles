using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rupee : PrefabClass
{
    private readonly string itemName;

    public Rupee()
    {
        itemName = "Rupee";

    }

    public override string item
    {
        get { return itemName; }
    }


}
