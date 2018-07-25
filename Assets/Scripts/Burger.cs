using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : MonoBehaviour
{
    private Transform m_ingridientContainer;
    private Transform m_sauceBottlePlaceholder;

    public void AddIngridient(GameObject go)
    {
        if (IsFinished())
            return;

        if (HasAllIngridients())
        {
            m_ingridientContainer.GetComponentInChildren<BurgerBox>().CloseBox();
            return;
        }

        if (IsEmpty() && go.GetComponent<BurgerBox>() != null)
        {
            Mover.Get().Move(go.transform, m_ingridientContainer);
            //Debug.Break();
        }
        else if (IsInProgress())
        {
            if (go.GetComponent<Beef>() != null ||
                go.GetComponent<HalfBanBottom>() != null ||
                go.GetComponent<HalfBanTop>() != null ||
                go.GetComponent<Cheese>() != null ||
                go.GetComponent<Sauce>() != null)
            {
                var bounds = Utils.GetBounds(m_ingridientContainer.gameObject);
                // Utils.SetParentAndResetTransform(go.transform, m_ingridientContainer);
                Mover.Get().Move(go.transform, m_ingridientContainer, new Vector3(0, bounds.size.y, 0));
                //go.transform.localPosition = go.transform.localPosition + );
            }
        }
    }

    public OrderElement GetOrderElement()
    {
        var orderElement = new OrderElement("", 0, 0);
        return orderElement;
    }

    public void OnTouched()
    {
        if (!IsFinished() && HasAllIngridients() && !IsBoxClosed())
        {
            m_ingridientContainer.GetComponentInChildren<BurgerBox>().CloseBox();
            return;
        }

        var cook = Cook.Get();

        if (IsInProgress() && cook.IsHolding<SauceBottle>())
        {
            var sauceBottle = cook.GetRightHand<SauceBottle>();
            cook.DropRightHand(m_sauceBottlePlaceholder);
            sauceBottle.SpreadSauce(() =>
            {
                cook.GrabRightHand(sauceBottle.gameObject);
            });

            var sauce = ObjectFactory.Get().CreateSauce();
            sauce.transform.position = transform.position;
            sauce.transform.rotation = transform.rotation;
            sauce.PlayAppearAnimation();
            AddIngridient(sauce.gameObject);

        }
        else if (IsFinished() && cook.Inventory.IsRightHandFree)
            cook.GrabRightHand(transform.gameObject);
        else if (!cook.Inventory.IsRightHandFree)
        {
            AddIngridient(cook.Inventory.RightHand);
            cook.DropRightHand();
        }
    }

    public bool IsEmpty()
    {
        return m_ingridientContainer.childCount == 0;
    }

    public bool IsFinished()
    {
        return HasAllIngridients() && IsBoxClosed();
    }

    public bool IsBoxClosed()
    {
        var burgerBox = m_ingridientContainer.GetComponentInChildren<BurgerBox>();
        if (burgerBox == null)
            return false;

        return burgerBox.IsClosed();
    }

    public bool HasAllIngridients()
    {
        return !IsEmpty() && m_ingridientContainer.GetComponentInChildren<HalfBanTop>() != null;
    }

    public bool IsInProgress()
    {
        return !IsEmpty() && !IsFinished();
    }

    void Awake()
    {
        m_ingridientContainer = transform.Find("IngridientContainer");
        m_sauceBottlePlaceholder = transform.Find("SauceBottlePlaceholder");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
