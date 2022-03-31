/*
 * Filename:  Aggregate.cs
 * Developer: Toby Mclenon
 * Purpose:   This file contains an abstract class to create the inventory data structure
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: This Class serves as an abstract class to create the inventory data structure
 */
public abstract class Aggregate
{
    public abstract Iterator CreateIterator();
}