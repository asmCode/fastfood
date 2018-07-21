using System.Collections;
using System.Collections.Generic;

public class Order
{
    public float BasePrice { get; set; }
    public float BaseTime { get; set; }

    public Order()
    {
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
        Order order = new Order();
        order.m_orderElements = new List<OrderElement>(m_orderElements);
        return order;
    }
}
