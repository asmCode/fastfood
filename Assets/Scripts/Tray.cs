using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour
{
    private Transform m_burgerPlaceholder;
    private Transform m_cupPlaceholder;

    public void OnTouched()
    {
        if (Cook.Get().IsHolding<Burger>())
            Cook.Get().DropRightHand(m_burgerPlaceholder);

        if (Cook.Get().IsHolding<Cup>())
            Cook.Get().DropRightHand(m_cupPlaceholder);
    }

    void Awake()
    {
        m_burgerPlaceholder = transform.Find("BurgerPlaceholder");
        m_cupPlaceholder = transform.Find("CupPlaceholder");
    }

    public Order GetOrder()
    {
        var element1 = m_burgerPlaceholder.GetComponentInChildren<OrderElementRoot>();
        var element2 = m_cupPlaceholder.GetComponentInChildren<OrderElementRoot>();

        var order = new Order(0);
        if (element1 != null)
            order.OrderElements.Add(element1.GetOrderElement());
        if (element2 != null)
            order.OrderElements.Add(element2.GetOrderElement());

        return order;
    }
}
