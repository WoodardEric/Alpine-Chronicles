/*
 * Filename:  InventoryClass.cs
 * Developer: Toby Mclenon
 * Purpose:   This file contains a class defining an inventory using the
 *            aggregate data structure and its iterator
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: This Class acts as an inventory by implementing the aggregate data structure
 *          and its iterator. This class serves as a superclass to the PlayerInvetory class
 *
 * Member Variables: 
 * inventory - The aggregate data structure defined in the ConcreteAggregate class
 * MAX_INV_SIZE - A constant integer which holds the maximum number of items allow in the inventory
 * currentAmt - An integer which holds the current number of items in the inventory
 */
public class InventoryClass : MonoBehaviour
{
    protected ConcreteAggregate inventory = null;
    const int MAX_INV_SIZE = 20;
    protected int currentAmt;


    /*
     * Summary: initilizes class instance variables
     */
    void Start()
    {
        // Initialize variables
        currentAmt = 0;
        inventory = new ConcreteAggregate();
    }


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
        if (inventory.count >= MAX_INV_SIZE)
        {
            return false;
        }

        // Otherwise, add item and increment number of items in inventory
        inventory[inventory.count] = addedItem;
        ++currentAmt;
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
        // Check if the item can be deleted, if so, decrement number of items in inventory
        bool isDeleted = inventory.DeleteItem(index);
        if (isDeleted)
        {
            --currentAmt;
        }
        
        // Return whether the item was removed or not
        return isDeleted;
    }


    /*
     * Summary: Removes an item to the inventory data structure and indicates success or failure
     *
     * Parameters:
     * nameOfItem - The name of the item to be removed from the inventory
     *
     * Returns:
     * bool - Return true if the item was removed and false if it was not
     */
    public bool RemoveItem(string nameOfItem)
    {
        // Initialize index of found item to eror value
        int foundIndex = -1;
        // Look for the item in the inventory
        for (int i = 0; i < inventory.count; ++i)
        {
            ItemClass temp = (ItemClass) inventory[i];
            // If the item is found, record its index and leave the loop
            if (temp.itemName.Equals(nameOfItem, StringComparison.Ordinal))
            {
                foundIndex = i;
                break;
            }
        }

        // Check if the item can be deleted, if so, decrement number of items in inventory
        bool isDeleted = inventory.DeleteItem(foundIndex);
        if(isDeleted)
        {
            --currentAmt;
        }

        // Return whether the item was removed or not
        return isDeleted;
    }


    /*
     * Summary: Returns the current number of items in the inventory
     *
     * Returns:
     * int - Returns the current number of items in the inventory
     */
    public int GetNumItems()
    {
        return currentAmt;
    }


    /*
     * Summary: Returns the maximum size of the inventory
     *
     * Returns:
     * int - Returns the maximum size of the inventory
     */
    public int GetMaxItems()
    {
        return MAX_INV_SIZE;
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
        if (index >= currentAmt)
        {
            return null;
        }

        return (ItemClass) inventory[index];
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
        // Search for item in inventory
        for (int i = 0; i < MAX_INV_SIZE; ++i)
        {
            ItemClass temp = (ItemClass) inventory[i];
            if (temp.itemName.Equals(name, StringComparison.Ordinal))
            {
                // If item found, return it
                return (ItemClass) inventory[i];
            }
        }

        // If item was not found, return null
        return null;
    }

    public void ResetInventory()
    {
        for (int i = 0; i < currentAmt;)
        {
            RemoveItem(i);
        }
    }
}
