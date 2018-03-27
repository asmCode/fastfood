using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauceBottle : MonoBehaviour
{
    private Animator m_animator;

    void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    public void SpreadSauce()
    {
        m_animator.Play("SpreadSauce", 0, 0);
    }
}
