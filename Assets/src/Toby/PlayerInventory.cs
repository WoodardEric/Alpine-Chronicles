using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : InventoryClass
{
    // Start is called before the first frame update
    void Start()
    {
        currentAmt = 0;
        itemsTest = new ConcreteAggregate();
    }

    public bool SwitchItems(int itemOne, int itemTwo)
    {
        if (itemOne < 0 || itemOne >= itemsTest.Count)
        {
            return false;
        }
        
        if (itemTwo < 0 || itemTwo >= itemsTest.Count)
        {
            return false;
        }

        if (itemsTest[itemOne] == null || itemsTest[itemTwo] == null)
        {
            return false;
        }

        ItemClass temp = (ItemClass) itemsTest[itemOne];
        itemsTest[itemOne] = itemsTest[itemTwo];
        items[itemTwo] = temp;
        return true;
    }

    public (bool, ItemClass) SwitchEquipped(int index, ItemClass item)
    {
        if (index < 0 || index >= GetMaxItems())
        {
            return (false, null);
        }

        if (index >= itemsTest.Count)
        {
            itemsTest[itemsTest.Count] = item;
            ++currentAmt;
            return (true, null);
        }

        if (itemsTest[index] == null)
        {
            itemsTest[index] = item;
            ++currentAmt;
            return (true, null);
        }

        ItemClass temp = (ItemClass) itemsTest[index];
        itemsTest[index] = item;
        return (true, temp);
    }

    public void CreateTestList()
    {
        if (itemsTest == null)
        {
            itemsTest = new ConcreteAggregate();
        }
    }
}
