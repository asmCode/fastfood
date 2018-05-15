using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderList : MonoBehaviour
{
    public OrderView m_orderViewPrefab;

    public void AddOrder(int orderId, string text, float timeLimit, float reward)
    {
        var orderView = Instantiate(m_orderViewPrefab);
        orderView.transform.SetParent(this.transform, false);
        orderView.SetData(orderId, text, timeLimit, reward);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            AddOrder(0, "1. HAMBURGER\n\t- NO MEAT\n2. COCA COLA\n\t- NO ICE", Time.time + 2.0f, 4.79f);
        }
    }
}
