/*
 * Filename:  PlayerInventory.cs
 * Developer: Toby Mclenon
 * Purpose:   This file contains a subclass of InventoryClass and defines the player's inventory
 */
 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: This Class acts is a subclass of InventoryClass and acts as a definition
 *          for the player's inventory
 */
public class PlayerInventory : ConcreteAggregate
{
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
        if (count == 0)
        {
            return false;
        }

        for (int i = 0; i < count; ++i)
        {
            ItemClass tempItem = (ItemClass) items[i];
            if (tempItem.itemName.Equals(nameOfItem, StringComparison.Ordinal))
            {
                if (i == count - 1)
                {
                    this.items[i] = null;
                    --count;
                    return true;
                }
                else
                {
                    for (int k = i; k < count - 1; ++k)
                    {
                        this.items[k] = this.items[k + 1];
                    }
                    this.items[--count] = null;
                    return true;
                }
            }
        }
        // Initialize index of found item to eror value
        return false;
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
        if (itemOne < 0 || itemOne >= this.count)
        {
            return false;
        }
        
        // Check bounds of second index
        if (itemTwo < 0 || itemTwo >= this.count)
        {
            return false;
        }

        // Check if either item doesn't exist
        if (this.items[itemOne] == null || this.items[itemTwo] == null)
        {
            return false;
        }

        // Swap the items
        ItemClass temp = (ItemClass) this.items[itemOne];
        this.items[itemOne] = this.items[itemTwo];
        this.items[itemTwo] = temp;
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
    public (bool, ItemClass) SwitchEquippedWeapon(int index, ItemClass item)
    {
        // Check if the index is within bounds of inventory
        if (index < 0 || index >= GetMaxItems())
        {
            return (false, null);
        }


        // Check if player is putting equipped item into inventory without swapping another item in
        if (index >= this.count)
        {
            //if ((this.count >= GetMaxItems()) || (item == null))
            //{
            return (false, null);
            //}

            //this.items[this.count] = item;
            //return (true, null);
        }

        if (item == null)
        {
            if (this.items[index] == null)
            {
                return (false, null);
            }

            ItemClass tempItem = (ItemClass) this.items[index];
            if (tempItem.itemType == "Weapon")
            {
                RemoveItem(index);
                return (true, tempItem);
            }
            return (false, null);
            
        }

        // Check if player is placing equipped item into empty inventory slot
        if (this.items[index] == null)
        {
            this.items[index] = item;
            return (true, null);
        }

        

        // If item swapped exists, swap it to equip slot of player
        ItemClass temp = (ItemClass) this.items[index];
        if (temp.itemType == "Weapon")
        {
            this.items[index] = item;
            return (true, temp);
        }
        return (false, null);
    }

    public (bool, ItemClass) SwitchEquippedUtil(int index, ItemClass item)
    {
        // Check if the index is within bounds of inventory
        if (index < 0 || index >= GetMaxItems())
        {
            return (false, null);
        }


        // Check if player is putting equipped item into inventory without swapping another item in
        if (index >= this.count)
        {
            //if ((this.count >= GetMaxItems()) || (item == null))
            //{
            return (false, null);
            //}

            //this.items[this.count] = item;
            //return (true, null);
        }

        if (item == null)
        {
            if (this.items[index] == null)
            {
                return (false, null);
            }

            ItemClass tempItem = (ItemClass) this.items[index];
            if (tempItem.itemType == "Utility")
            {
                RemoveItem(index);
                return (true, tempItem);
            }
            return (false, null);
        }

        // Check if player is placing equipped item into empty inventory slot
        if (this.items[index] == null)
        {
            this.items[index] = item;
            return (true, null);
        }

        

        // If item swapped exists, swap it to equip slot of player
        ItemClass temp = (ItemClass) this.items[index];
        if (temp.itemType == "Utility")
        {
            this.items[index] = item;
            return (true, temp);
        }
        return (false, null);
    }
}
