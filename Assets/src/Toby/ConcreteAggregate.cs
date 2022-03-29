using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteAggregate : Aggregate
{
    List<object> items = new List<object>();
    public override Iterator CreateIterator()
    {
        return new ConcreteIterator(this);
    }
    // Get item count
    public int Count
    {
        get { return items.Count; }
    }
    // Indexer
    public object this[int index]
    {
        get { return items[index]; }
        set { items.Insert(index, value); }
    }

    public bool DeleteItem(int index)
    {
        if (index >= Count || index < 0)
        {
            return false;
        }
        items.RemoveAt(index);
        return true;
    }
}
