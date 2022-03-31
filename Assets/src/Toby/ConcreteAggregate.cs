/*
 * Filename:  ConcreteAggregate.cs
 * Developer: Toby Mclenon
 * Purpose:   This file contains an implementation class for the Aggregate class
 *            and actually creates the inventory
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: This Class serves as a definition class to create the inventory data structure
 *
 * Member Variables: 
 * items - a list of C# generic object type
 * count - An integer which holds the current number of elements in the list
 */
public class ConcreteAggregate : Aggregate
{
    List<object> items = new List<object>();


    /*
     * Summary: Returns an Iterator
     *
     * Returns:
     * Iterator - Return a new Iterator
     */
    public override Iterator CreateIterator()
    {
        return new ConcreteIterator(this);
    }

    
    // Get item count
    public int count
    {
        get { return items.Count; }
    }


    // Indexer
    public object this[int index]
    {
        get { return items[index]; }
        set { items.Insert(index, value); }
    }


    /*
     * Summary: Deletes an item from the data structure and indicates success or failure
     *
     * Parameters:
     * index - The index of the item to delete from the inventory
     *
     * Returns:
     * bool - Return true if the item was removed and false if it was not
     */
    public bool DeleteItem(int index)
    {
        // Check if the index is out of bounds or if the item to be deleted doesn't exist
        if (index >= count || index < 0 || items[index] == null)
        {
            return false;
        }
        
        // If item exists, remove item
        items.RemoveAt(index);
        return true;
    }
}