using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : InventoryClass
{
    // Start is called before the first frame update
    void Start()
    {
        currentAmt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool SwitchItems(int itemOne, int itemTwo)
    {
        if (itemOne < 0 || itemOne >= this.GetMaxItems())
        {
            return false;
        }
        
        if (itemTwo < 0 || itemTwo >= this.GetMaxItems())
        {
            return false;
        }

        if (items[itemOne] == null && items[itemTwo] == null)
        {
            return false;
        }
        ItemClass temp = items[itemOne];
        items[itemOne] = items[itemTwo];
        items[itemTwo] = temp;
        return true;
    }

    public (bool, ItemClass) SwitchEquipped(int index, ItemClass item)
    {
        if (index < 0 || index >= this.GetMaxItems())
        {
            return (false, null);
        }

        if (items[index] == null)
        {
            items[index] = item;
            ++currentAmt;
            return (true, null);
        }

        ItemClass temp = items[index];
        items[index] = item;
        return (true, temp);
    }
}
