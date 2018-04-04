using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerAssembler : MonoBehaviour
{
    private Transform m_burgerPlaceholder;

    public void OnTouched()
    {
        var burger = GetBurger();

        if (burger != null)
            return;

        var cook = Cook.Get();
        if (cook.Inventory.IsRightHandFree || cook.Inventory.RightHand.GetComponent<BurgerBox>() == null)
            return;

        burger = ObjectFactory.Get().CreateBurger();
        Utils.SetParentAndResetTransform(burger.transform, m_burgerPlaceholder.transform);
        burger.AddIngridient(cook.Inventory.RightHand);

        cook.DropRightHand();
    }

    private Burger GetBurger()
    {
        if (m_burgerPlaceholder.childCount == 0)
            return null;

        return m_burgerPlaceholder.GetComponentInChildren<Burger>();
    }

    // Use this for initialization
    void Awake()
    {
        m_burgerPlaceholder = transform.Find("BurgerPlaceholder");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
