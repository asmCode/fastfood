using System;
using System.Collections;
using System.Collections.Generic;

public class OrderElement : List<ProductType>
{
    public string Name
    {
        get;
        private set;
    }

    public OrderElement(string name)
    {
        Name = name;
    }

    public OrderElement Clone()
    {
        var clone = new OrderElement(Name);
        clone.InsertRange(0, this);
        return clone;
    }
}
