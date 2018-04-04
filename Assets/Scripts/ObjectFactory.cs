using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFactory : MonoBehaviour
{
    public HalfBanBottom m_halfBanBottomPrefab;
    public HalfBanTop m_halfBanTopPrefab;
    public Burger m_burgerPrefab;
    public Sauce m_saucePrefab;

    private static ObjectFactory m_instance;

    public static ObjectFactory Get()
    {
        if (m_instance == null)
            m_instance = GameObject.Find("ObjectFactory").GetComponent<ObjectFactory>();

        return m_instance;
    }

    public HalfBanBottom CreateHalfBanBottom()
    {
        return Instantiate(m_halfBanBottomPrefab);
    }

    public HalfBanTop CreateHalfBanTop()
    {
        return Instantiate(m_halfBanTopPrefab);
    }

    public Burger CreateBurger()
    {
        return Instantiate(m_burgerPrefab);
    }

    public Sauce CreateSauce()
    {
        return Instantiate(m_saucePrefab);
    }
}
    