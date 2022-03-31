/*
 * Filename:  PlayerInventory.cs
 * Developer: Toby Mclenon
 * Purpose:   This file contains a subclass of InventoryClass and defines the player's inventory
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: This Class acts is a subclass of InventoryClass and acts as a definition
 *          for the player's inventory
 */
public class PlayerInventory : InventoryClass
{
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
     * Summary: Switches the positions of two items in the inventory
     *
     * Parameters:
     * itemOne - The index of the first item to be swapped
     * itemTwo - The index of the second item to be swapped
     *
     * Returns:
     * bool - Return true if the items were switched and false if they were not
     */
    public bool SwitchItems(int itemOne, int itemTwo)
    {
        // Check bounds of first index
        if (itemOne < 0 || itemOne >= inventory.count)
        {
            return false;
        }
        
        // Check bounds of second index
        if (itemTwo < 0 || itemTwo >= inventory.count)
        {
            return false;
        }

        // Check if either item doesn't exist
        if (inventory[itemOne] == null || inventory[itemTwo] == null)
        {
            return false;
        }

        // Swap the items
        ItemClass temp = (ItemClass) inventory[itemOne];
        inventory[itemOne] = inventory[itemTwo];
        inventory[itemTwo] = temp;
        return true;
    }


    /*
     * Summary: Switches the currently equipped item with an item from the inventory
     *
     * Parameters:
     * index - The index of the item in inventory to be swapped
     * item - The currently equipped item to be placed into the inventory
     *
     * Returns:
     * bool - Return true if the items were switched and false if they were not
     * ItemClass - the item that is to be swapped into the player's equip slot
     */
    public (bool, ItemClass) SwitchEquipped(int index, ItemClass item)
    {
        // Check if the index is within bounds of inventory
        if (index < 0 || index >= GetMaxItems())
        {
            return (false, null);
        }

        // Check if player is putting equipped item into inventory without swapping another item in
        if (index >= inventory.count)
        {
            inventory[inventory.count] = item;
            ++currentAmt;
            return (true, null);
        }

        // Check if player is placing equipped item into empty inventory slot
        if (inventory[index] == null)
        {
            inventory[index] = item;
            ++currentAmt;
            return (true, null);
        }

        // If item swapped exists, swap it to equip slot of player
        ItemClass temp = (ItemClass) inventory[index];
        inventory[index] = item;
        return (true, temp);
    }


    /*
     * Summary: A function to make testing easier. Creates an inventory since the start function
     *          is not called in edit mode tests. But in the even of it being used in production
     *          it first checks whether an inventory already exists.
     */
    public void CreateTestList()
    {
        if (inventory == null)
        {
            inventory = new ConcreteAggregate();
        }
    }
}
