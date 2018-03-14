using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    private Animator m_animator;

    private bool m_isClosed = true;

    public void DoorsTouched()
    {
        if (m_isClosed)
        {
            m_isClosed = false;
            m_animator.Play("TableOpen", 0, 0);
        }
        else
        {
            m_isClosed = true;
            m_animator.Play("TableClose", 0, 0);
        }
    }

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }
}
