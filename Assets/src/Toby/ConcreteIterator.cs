/*
 * Filename:  ConcreteIterator.cs
 * Developer: Toby Mclenon
 * Purpose:   This file contains an implementation class for the Iterator class
 *            and actually creates the Iterator for the Aggregate class
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: This Class serves as a definition class to create the
 *          Iterator for the aggregate data structure
 *
 * Member Variables: 
 * aggregate - The aggregate data structure defined in the ConcreteAggregate class
 * current - An integer which holds the current iterator position
 */
public class ConcreteIterator : Iterator
{
    ConcreteAggregate aggregate;
    int current = 0;


    // Constructor
    public ConcreteIterator(ConcreteAggregate aggregate)
    {
        this.aggregate = aggregate;
    }


    /*
     * Summary: Gets the first iteration item
     *
     * Returns:
     * object - The object retrieved at the first index of the data structure
     */
    public override object First()
    {
        return aggregate[0];
    }


    /*
     * Summary: Gets the next iteration item
     *
     * Returns:
     * object - The next object in the list, or null if the end of the list is reached
     */
    public override object Next()
    {
        object ret = null;
        if (current < aggregate.count - 1)
        {
            ret = aggregate[++current];
        }
        return ret;
    }


    /*
     * Summary: Gets the current iteration item
     *
     * Returns:
     * object - The object at the current location of the iterator
     */
    public override object CurrentItem()
    {
        return aggregate[current];
    }

    
    /*
     * Summary: Gets whether iterations are complete
     *
     * Returns:
     * bool - True if the list has been fully iterated through, false if not
     */
    public override bool IsDone()
    {
        return current >= aggregate.count;
    }
}
