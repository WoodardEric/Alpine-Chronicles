using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomKey1Factory : ItemFactory
{
    public override ItemClass GetItemClass()
    {
        return new RoomKey1();
    }
}