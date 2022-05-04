/*
 * Filename:  ConcreteAggregate.cs
 * Developer: Toby Mclenon
 * Purpose:   This file contains an implementation class for the Aggregate class
 *            and actually creates the inventory
 */
using System;
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
public class ConcreteAggregate
{
    //protected List<object> items = new List<object>();
    protected ItemClass []items = new ItemClass[20];
    const int constMaxInvSize = 20;
    public int count = 0;


    /*
     * Summary: Adds an item to the inventory data structure and indicates success or failure
     *
     * Parameters:
     * addedItem - The item to be added to the inventory
     *
     * Returns:
     * bool - Return true if the item was added and false if it was not
     */
    public bool AddItem(ItemClass addedItem)
    {
        // If the inventory is at max capacity, item can't be added
        if (count >= constMaxInvSize)
        {
            return false;
        }

        // Otherwise, add item to inventory
        this.items[count++] = addedItem;
        return true;
    }


    /*
     * Summary: Removes an item to the inventory data structure and indicates success or failure
     *
     * Parameters:
     * index - The index of the item to be removed from the inventory
     *
     * Returns:
     * bool - Return true if the item was removed and false if it was not
     */
    public bool RemoveItem(int index)
    {
        if (index >= count || index < 0)
        {
            return false;
        }
        
        if (index == count - 1)
        {
            this.items[index] = null;
            --count;
            return true;
        }
        
        for (int i = index; i < count - 1; ++i)
        {
            this.items[i] = this.items[i + 1];
        }
        
        this.items[--count] = null;
        return true;
    }


    /*
     * Summary: Returns the maximum size of the inventory
     *
     * Returns:
     * int - Returns the maximum size of the inventory
     */
    public int GetMaxItems()
    {
        return constMaxInvSize;
    }


    /*
     * Summary: Returns the item at the given index
     *
     * Parameters:
     * index - The index of the item to retrieve
     *
     * Returns:
     * ItemClass - Returns the item at the given index, or null if no such item exists
     */
    public ItemClass GetItem(int index)
    {
        if (index >= count)
        {
            return null;
        }

        return (ItemClass) items[index];
    }


    /*
     * Summary: Returns the item at the given index
     *
     * Parameters:
     * name - The name of the item to retrieve
     *
     * Returns:
     * ItemClass - Returns the item with the given name, or null if no such item exists
     */
    public ItemClass GetItem(string name)
    {
        if (count == 0)
        {
            return null;
        }

        for (int i = 0; i < count; ++i)
        {
            if (items[i].itemName.Equals(name, StringComparison.Ordinal))
            {
                return items[i];
            }
        }

        return null;
    }

    public void ResetInventory()
    {
        for (int i = 0; i < GetMaxItems(); ++i)
        {
            items[i] = null;
        }
    }
}