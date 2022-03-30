using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomKey2Factory : ItemFactory
{
    public override ItemClass GetItemClass()
    {
        return new RoomKey2();
    }
}