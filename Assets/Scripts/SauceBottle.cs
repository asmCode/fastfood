using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauceBottle : MonoBehaviour
{
    private Animator m_animator;
    private System.Action m_animationFinishedCallback;

    void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    public void SpreadSauce(System.Action animationFinishedCallback)
    {
        m_animationFinishedCallback = animationFinishedCallback;
        m_animator.Play("SpreadSauce", 0, 0);
    }

    public void AnimEvent_Finished()
    {
        if (m_animationFinishedCallback != null)
            m_animationFinishedCallback();
    }
}
