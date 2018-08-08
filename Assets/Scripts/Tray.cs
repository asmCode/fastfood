using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour
{
    private Transform m_burgerPlaceholder;
    private Transform m_cupPlaceholder;

    public void OnTouched()
    {
        if (Cook.Get().Inventory.IsRightHandFree)
        {
        }
        else
        {
            if (Cook.Get().IsHolding<Burger>() && GetBurger() == null)
                Cook.Get().DropRightHand(m_burgerPlaceholder);

            if (Cook.Get().IsHolding<Cup>() && GetCup() == null)
                Cook.Get().DropRightHand(m_cupPlaceholder);
        }
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

    public GameObject GetCup()
    {
        if (m_cupPlaceholder.childCount == 0)
            return null;

        return m_cupPlaceholder.GetChild(0).gameObject;
    }

    public GameObject GetBurger()
    {
        if (m_burgerPlaceholder.childCount == 0)
            return null;

        return m_burgerPlaceholder.GetChild(0).gameObject;
    }
}
