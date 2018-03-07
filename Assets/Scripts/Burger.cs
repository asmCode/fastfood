using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : MonoBehaviour
{
    private Transform m_ingridientContainer;

    public void AddIngridient(GameObject go)
    {
        if (IsFinished())
            return;

        if (IsEmpty() && go.GetComponent<HalfBanBottom>() != null)
        {
            Utils.SetParentAndResetTransform(go.transform, m_ingridientContainer);
        }
        else if (IsInProgress())
        {
            if (go.GetComponent<Beef>() != null || go.GetComponent<HalfBanTop>() != null)
            {
                var bounds = Utils.GetBounds(gameObject);
                Utils.SetParentAndResetTransform(go.transform, m_ingridientContainer);
                go.transform.localPosition = go.transform.localPosition + new Vector3(0, bounds.size.y, 0);
            }
        }
    }

    public void OnTouched()
    {
        var cook = Cook.Get();

        if (IsFinished() && cook.Inventory.IsRightHandFree)
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
        return !IsEmpty() && m_ingridientContainer.GetComponentInChildren<HalfBanTop>() != null;
    }

    public bool IsInProgress()
    {
        return !IsEmpty() && !IsFinished();
    }

    void Awake()
    {
        m_ingridientContainer = transform.Find("IngridientContainer");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
