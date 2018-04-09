using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHelper : MonoBehaviour
{
    private Animator m_animator;
    private System.Action m_animationFinished;

    public void Play(string animationName, System.Action animationFinishedCallback)
    {
        if (m_animator == null)
            return;

        m_animationFinished = animationFinishedCallback;

        m_animator.Play(animationName, 0, 0.0f);
    }

    public void AnimEvent_AnimationFinished()
    {
        if (m_animationFinished != null)
            m_animationFinished();
    }

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }
}
