/*
* Filename: ItemClassFactory.cs
* Developer: Sophia Sivula
* Purpose: This file implements the factory pattern for the ItemClass
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: subclass of ItemFactory for the ItemClass, creating the factory pattern  
*/
public abstract class ItemFactory
{
    public abstract ItemClass GetItemClass();
}