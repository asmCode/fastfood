using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerBox : MonoBehaviour
{
    private Animator m_animator;

    private bool m_isClosed = false;

    public void CloseBox()
    {
        m_isClosed = true;
        m_animator.Play("BurgerBoxClose", 0, 0);
    }

    public bool IsClosed()
    {
        return m_isClosed;
    }

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }
}
