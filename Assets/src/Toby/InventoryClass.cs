using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryClass : MonoBehaviour
{
    const int MAX_INV_SIZE = 20;
    protected int currentAmt;
    protected ItemClass[] items = new ItemClass[MAX_INV_SIZE];

    // Start is called before the first frame update
    void Start()
    {
        currentAmt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AddItem(ItemClass addedItem)
    {
        if (currentAmt < MAX_INV_SIZE)
        {
            for (int i = 0; i <= currentAmt; ++i)
            {
                if (items[i] == null)
                {
                    items[i] = addedItem;
                }
            }
            ++currentAmt;
            return true;
        }

        return false;
    }

    public bool RemoveItem(int index)
    {
        if (currentAmt <= 0)
        {
            return false;
        }

        if (index < 0 || index >= MAX_INV_SIZE)
        {
            return false;
        }

        if (items[index] == null)
        {
            return false;
        }

        items[index] = null;
        --currentAmt;

        return true;
    }

    public bool RemoveItem(string nameOfItem)
    {
        for (int i = 0; i < this.GetMaxItems(); ++i)
        {
            if (items[i].itemName.Equals(nameOfItem, StringComparison.Ordinal))
            {
                items[i] = null;
                return true;
            }
        }

        return false;
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
        return items[index];
    }

    
}
