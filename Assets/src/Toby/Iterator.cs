/*
 * Filename:  Iterator.cs
 * Developer: Toby Mclenon
 * Purpose:   This file contains an abstract class to create the iterator for
 *            the data structure defined in the Aggregate class
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: This Class serves as an abstract class to create the Iterator
 *          for the Aggregate data structure
 */
public abstract class Iterator
{
    public abstract object First();
    public abstract object Next();
    public abstract bool IsDone();
    public abstract object CurrentItem();
}
