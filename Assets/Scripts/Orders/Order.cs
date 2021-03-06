﻿using System.Collections;
using System.Collections.Generic;

public class Order
{
    public int Id { get; private set; }

    public Order(int id)
    {
        Id = id;
    }

    public float GetPrice()
    {
        float price = 0.0f;

        for (int i = 0; i < OrderElements.Count; i++)
            price += OrderElements[i].Price;

        return price;
    }

    private List<OrderElement> m_orderElements = new List<OrderElement>();

    public List<OrderElement> OrderElements
    {
        get { return m_orderElements; }
    }

    public static bool Compare(Order order1, Order order2)
    {
        if (order1.m_orderElements.Count != order2.m_orderElements.Count)
            return false;

        order1 = order1.Clone();
        order2 = order2.Clone();

        foreach (var orderElement1 in order1.m_orderElements)
        {
            var find = order2.m_orderElements.Find((t) => {
                return OrderElement.Compare(orderElement1, t);
            });

            if (find == null)
                return false;

            order2.m_orderElements.Remove(find);
        }

        return true;
    }

    public Order Clone()
    {
        Order order = new Order(Id);
        order.m_orderElements = new List<OrderElement>(m_orderElements);
        return order;
    }
}
