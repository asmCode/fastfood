using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    private GameObject m_drinkLevel;
    private GameObject m_drinkLevelTop;
    private GameObject m_drinkLevelBottom;
    private Transform m_lidPlaceholder;
    private Transform m_strawPlaceholder;
    private Material m_drinkLevelMaterial;

    private float m_level;
    
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

    public void SetDrinkColor(Color color)
    {
        m_drinkLevelMaterial.color = color;
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
