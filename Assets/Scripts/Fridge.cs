using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    private Animator m_animator;

    private bool m_isClosed = true;

    public void DoorsTouched()
    {
        //if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("FridgeOpen") ||
        //    m_animator.GetCurrentAnimatorStateInfo(0).IsName("FridgeClose"))
        //    return;

        if (m_isClosed)
        {
            m_isClosed = false;
            m_animator.Play("FridgeOpen", 0, 0);
        }
        else
        {
            m_isClosed = true;
            m_animator.Play("FridgeClose", 0, 0);
        }
    }

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }
}
