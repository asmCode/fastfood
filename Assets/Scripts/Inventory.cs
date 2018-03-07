using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private GameObject m_leftHand;
    private GameObject m_rightHand;

    public bool IsLeftHandFree
    {
        get
        {
            return LeftHand == null;
        }
    }

    public bool IsRightHandFree
    {
        get
        {
            return RightHand == null;
        }
    }

    public GameObject LeftHand
    {
        get
        {
            return m_leftHand;
        }
    }

    public GameObject RightHand
    {
        get
        {
            return m_rightHand;
        }
    }

    public void SetRightHand(GameObject gameObject)
    {
        m_rightHand = gameObject;
    }

    public void SetLeftHand(GameObject gameObject)
    {
        m_leftHand = gameObject;
    }
}
