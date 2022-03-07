using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryClass : MonoBehaviour
{
    const int MAX_INV_SIZE = 20;
    int currentAmt;
    //Item[] items = new Item[MAX_INV_SIZE];

    // Start is called before the first frame update
    void Start()
    {
        currentAmt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool addItem(/*Item addedItem*/)
    {
        if (currentAmt < MAX_INV_SIZE)
        {
            // items[currentAmt] = addedItem;
            ++currentAmt;
            return true;
        }

        return false;
    }

    public bool removeItem(/*Item removedItem*/)
    {
        if (currentAmt > 0)
        {
            // items[currentAmt] = addedItem;
            --currentAmt;

            return true;
        }

        return false;
    }

    public int getNumItems()
    {
        return currentAmt;
    }

    public int getMaxItems()
    {
        return MAX_INV_SIZE;
    }
}
