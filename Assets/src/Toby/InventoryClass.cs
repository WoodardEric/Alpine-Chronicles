using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryClass : MonoBehaviour
{
    protected ConcreteAggregate itemsTest = null;
    const int MAX_INV_SIZE = 20;
    protected int currentAmt;
    protected ItemClass[] items = new ItemClass[MAX_INV_SIZE];

    void Start()
    {
        currentAmt = 0;
        itemsTest = new ConcreteAggregate();
    }

    public bool AddItem(ItemClass addedItem)
    {
        if (itemsTest.Count >= MAX_INV_SIZE)
        {
            return false;
        }

        itemsTest[itemsTest.Count] = addedItem;
        ++currentAmt;
        return true;
    }

    public bool RemoveItem(int index)
    {
        bool isDeleted = itemsTest.DeleteItem(index);

        if (isDeleted)
        {
            --currentAmt;
        }
        return isDeleted;
    }

    public bool RemoveItem(string nameOfItem)
    {
        int foundIndex = -1;
        for (int i = 0; i < itemsTest.Count; ++i)
        {
            ItemClass temp = (ItemClass) itemsTest[i];
            if (temp.itemName.Equals(nameOfItem, StringComparison.Ordinal))
            {
                foundIndex = i;
                break;
            }
        }
        bool isDeleted = itemsTest.DeleteItem(foundIndex);

        if(isDeleted)
        {
            --currentAmt;
        }
        return isDeleted;
    }

    public int GetNumItems()
    {
        return currentAmt;
    }

    public int GetMaxItems()
    {
        return MAX_INV_SIZE;
    }

    public ItemClass GetItem(int index)
    {
        if (index >= currentAmt)
        {
            return null;
        }
        return (ItemClass) itemsTest[index];
    }

    public ItemClass GetItem(string name)
    {
        for (int i = 0; i < MAX_INV_SIZE; ++i)
        {
            ItemClass temp = (ItemClass) itemsTest[i];
            if (temp.itemName.Equals(name, StringComparison.Ordinal))
            {
                return (ItemClass) itemsTest[i];
            }
        }
        return null;
    }
}
