/*
 * Filename:  Rupee.cs
 * Developer: Riley Walsh
 * Purpose:   This file contains an abstract class that creates getters, for items and strength of player.  
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* Summary: This Class defines getters for item, and strength. 
*
*/


public abstract class PrefabClass
{
    public abstract string item { get; }
    public virtual int strength { get; }

}
