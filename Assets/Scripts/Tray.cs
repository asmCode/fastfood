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
}
