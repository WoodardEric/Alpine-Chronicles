using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaFactory : ItemFactory
{
    public override ItemClass GetItemClass()
    {
        return new Katana();
    }
}