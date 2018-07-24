using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager m_instance;

    public OrderList m_orderList;

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
        
        // m_orderList.AddOrder(order, Id.NextId(), text, Time.time + time, price);
        m_orderList.AddOrder(order, 666, text, Time.time + time, price);
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
        return false;
    }
}
