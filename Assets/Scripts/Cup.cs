using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    private GameObject m_drinkLevel;
    private GameObject m_drinkLevelTop;
    private GameObject m_drinkLevelBottom;
    private Transform m_lidPlaceholder;

    private ProductType m_productType = ProductType.None;

    public OrderElement GetOrderElement()
    {
        var orderElement = new OrderElement("", 0, 0);

        orderElement.Add(ProductType.Cup);

        if (m_productType != ProductType.None)
            orderElement.Add(m_productType);

        if (HasIce())
            orderElement.Add(ProductType.Ice);

        if (HasStraw())
            orderElement.Add(ProductType.Straw);

        if (HasLid())
            orderElement.Add(ProductType.Lid);

        return orderElement;
    }

    private Transform m_strawPlaceholder;
    private Material m_drinkLevelMaterial;

    private float m_level;
    private bool m_ice;
    
    private void Awake()
    {
        m_drinkLevel = transform.Find("DrinkLevel").gameObject;
        m_drinkLevelTop = transform.Find("DrinkLevelTop").gameObject;
        m_drinkLevelBottom = transform.Find("DrinkLevelBottom").gameObject;
        m_drinkLevelMaterial = m_drinkLevel.GetComponent<Renderer>().material;
        m_drinkLevel.SetActive(false);

        m_lidPlaceholder = transform.Find("LidPlaceholder");
        m_strawPlaceholder = transform.Find("StrawPlaceholder");
    }

    public void OnTouched()
    {
        if (IsReady())
        {
            Cook.Get().GrabRightHand(gameObject);
            return;
        }

        if (!IsFull())
            return;

        if (!HasLid())
        {
            if (Cook.Get().IsHolding<Lid>())
                Cook.Get().DropRightHand(m_lidPlaceholder);

            return;
        }

        if (!HasStraw())
        {
            if (Cook.Get().IsHolding<Straw>())
                Cook.Get().DropRightHand(m_strawPlaceholder);

            return;
        }
    }

    public void SetDrinkType(ProductType productType)
    {
        m_productType = productType;
        m_drinkLevelMaterial.color = DrinkColor.GetDrinkColor(productType);
    }

    public void SetLevel(float level)
    {
        m_drinkLevel.SetActive(level > 0.0f);

        m_level = level;

        if (level == 0.0f)
            return;

        m_drinkLevel.transform.localPosition = Vector3.Lerp(m_drinkLevelBottom.transform.localPosition, m_drinkLevelTop.transform.localPosition, m_level);
        m_drinkLevel.transform.localScale = Vector3.Lerp(m_drinkLevelBottom.transform.localScale, m_drinkLevelTop.transform.localScale, m_level);
    }

    public void SetIce(bool ice)
    {
        m_ice = ice;
    }

    public bool HasIce()
    {
        return m_ice;
    }

    private bool HasLid()
    {
        return m_lidPlaceholder.GetComponentInChildren<Lid>() != null;
    }

    private bool HasStraw()
    {
        return m_strawPlaceholder.GetComponentInChildren<Straw>() != null;
    }

    private bool IsFull()
    {
        return m_level >= 1.0f;
    }

    private bool IsReady()
    {
        return HasLid() && HasStraw() && IsFull();
    }
}
