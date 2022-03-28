using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : InventoryClass
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchItems(int itemOne, int itemTwo)
    {
        ItemClass temp = items[itemOne];
        items[itemOne] = items[itemTwo];
        items[itemTwo] = temp;
    }

    public ItemClass SwitchEquipped(int index, ItemClass item)
    {
        if (items[index] == null)
        {
            items[index] = item;
            ++currentAmt;
            return null;
        }
        ItemClass temp = items[index];
        items[index] = item;
        return temp;
    }
}
