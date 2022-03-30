using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteIterator : Iterator
{
    ConcreteAggregate aggregate;
    int current = 0;


    // Constructor
    public ConcreteIterator(ConcreteAggregate aggregate)
    {
        this.aggregate = aggregate;
    }


    // Gets first iteration item
    public override object First()
    {
        return aggregate[0];
    }


    // Gets next iteration item
    public override object Next()
    {
        object ret = null;
        if (current < aggregate.Count - 1)
        {
            ret = aggregate[++current];
        }
        return ret;
    }


    // Gets current iteration item
    public override object CurrentItem()
    {
        return aggregate[current];
    }

    
    // Gets whether iterations are complete
    public override bool IsDone()
    {
        return current >= aggregate.Count;
    }
}
