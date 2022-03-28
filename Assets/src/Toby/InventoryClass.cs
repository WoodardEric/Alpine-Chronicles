using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            items[currentAmt] = addedItem;
            ++currentAmt;
            return true;
        }

        return false;
    }

    public bool RemoveItem(int index)
    {
        Debug.Log(currentAmt);
        if (currentAmt <= 0)
        {
            return false;
        }

        if (index < 0 || index > (currentAmt - 1))
        {
            return false;
        }

        if (index == (currentAmt - 1))
        {
            items[--currentAmt] = null;
            return true;
        }

        for (int i = index; i < (currentAmt - 1); ++i)
        {
            items[i] = items[i + 1];
        }
        items[--currentAmt] = null;

        return true;
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
