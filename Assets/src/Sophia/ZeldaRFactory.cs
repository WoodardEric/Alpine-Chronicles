
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: subclass of ItemFactory for BossKey, creating the factory pattern  
*/
public class ZeldaRFactory : ItemFactory
{
    /*
    * Summary: function to get the item class, BossKey
    * 
    * Returns:
    * BossKey() - returns a new BossKey when GetItemClass() is called
    */
    public override ItemClass GetItemClass()
    {
        return new ZeldaR();
    }
}
