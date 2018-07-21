using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public OrderList m_orderList;

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

            price = order.OrderElements[i].Price;
            time = order.OrderElements[i].Time;
        }
        
        m_orderList.AddOrder(order, Id.NextId(), text, Time.time + time, price);
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
    }
}
