using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomKeyTwoFactory : ItemFactory
{
    public override ItemClass GetItemClass()
    {
        return new RoomKeyTwo();
    }
}