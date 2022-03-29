using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Iterator
{
    public abstract object First();
    public abstract object Next();
    public abstract bool IsDone();
    public abstract object CurrentItem();
}
