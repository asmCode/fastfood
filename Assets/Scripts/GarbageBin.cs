using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBin : MonoBehaviour
{
    private Animator m_animator;
    private bool m_closed = true;

    void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    void Update()
    {

    }

    public void Touched()
    {
        if (m_closed)
        {
            m_animator.SetTrigger("Open");
            m_closed = false;
        }
        else
        {
            m_animator.SetTrigger("Close");
            m_closed = true;
        }
    }
}
