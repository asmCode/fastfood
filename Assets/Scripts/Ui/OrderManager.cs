using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager m_instance;

    public OrderList m_orderList;

    private List<Order> m_orders = new List<Order>();

    public static OrderManager Get()
    {
        if (m_instance == null)
            m_instance = GameObject.Find("OrderManager").GetComponent<OrderManager>(); ;

        return m_instance;
    }


    public void MakeNewOrder()
    {
        var order = Menu.Get().GetRandomOrder();
        float price = 0.0f;
        float time = 0.0f;

        string text = "";
        for (int i = 0; i < order.OrderElements.Count; i++)
        {
            text += string.Format("{0}. {1}", i + 1, order.OrderElements[i].Name);
            if (i != order.OrderElements.Count - 1)
                text += "\n";

            price += order.OrderElements[i].Price;
            time += order.OrderElements[i].Time;
        }

        m_orders.Add(order);
        m_orderList.AddOrder(order, text, Time.time + time, price);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            MakeNewOrder();
        if (Input.GetKeyDown(KeyCode.C))
            m_orderList.CompleteOrder(666, true);
    }

    public bool TryComplete(Order order)
    {
        foreach (var orderOnList in m_orders)
        {
            if (Order.Compare(orderOnList, order))
            {
                m_orders.Remove(order);
                m_orderList.CompleteOrder(orderOnList.Id, true);
                break;
            }
        }

        return false;
    }
}
