using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomKeyOneFactory : ItemFactory
{
    public override ItemClass GetItemClass()
    {
        return new RoomKeyOne();
    }
}