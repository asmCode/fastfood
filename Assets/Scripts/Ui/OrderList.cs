using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderList : MonoBehaviour
{
    public OrderView m_orderViewPrefab;

    public void AddOrder(Order order, string text, float timeLimit, float reward)
    {
        var orderView = Instantiate(m_orderViewPrefab);
        orderView.transform.SetParent(this.transform, false);
        orderView.SetData(order, text, timeLimit, reward);
        orderView.AnimationFinished += OrderView_AnimationFinished;
    }

    public void CompleteOrder(int orderId, bool success)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            var orderView = child.GetComponent<OrderView>();
            if (orderId == orderView.Order.Id)
            {
                orderView.Complete(success);
                break;
            }
        }
    }

    private void OrderView_AnimationFinished(OrderView orderView)
    {
        Destroy(orderView.gameObject);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            //AddOrder(0, "1. HAMBURGER\n\t- NO MEAT\n2. COCA COLA\n\t- NO ICE", Time.time + 2.0f, 4.79f);
        }
    }
}
