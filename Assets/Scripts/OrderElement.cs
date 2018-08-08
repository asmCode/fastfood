using System;
using System.Collections;
using System.Collections.Generic;

public class OrderElement : List<ProductType>
{
    public string Name
    {
        get;
        set;
    }

    public float Price
    {
        get;
        set;
    }

    public float Time
    {
        get;
        set;
    }

    public OrderElement(string name, float price, float time)
    {
        Name = name;
        Price = price;
        Time = time;
    }

    public OrderElement Clone()
    {
        var clone = new OrderElement(Name, Price, Time);
        clone.InsertRange(0, this);
        return clone;
    }

    public static bool Compare(OrderElement element1, OrderElement element2)
    {
        if (element1.Count != element2.Count)
            return false;

        element1 = element1.Clone();
        element2 = element2.Clone();

        element1.Sort();
        element2.Sort();

        for (int i = 0; i < element1.Count; i++)
        {
            if (element1[i] != element2[i])
                return false;
        }

        return true;
    }
}
