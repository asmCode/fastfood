using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderView : MonoBehaviour
{
    public Text m_textLabel;
    public Text m_timeLabel;
    public Text m_rewardLabel;
    public Image m_bg;

    public event System.Action<OrderView> AnimationFinished;

    private Animator m_animator;

    public Order Order
    {
        get;
        private set;
    }

    public bool IsDestroying
    {
        get;
        set;
    }

    public Color m_normalColor;
    public Color m_warningColor;
    public Color m_criticalColor;

    private float m_timeLimit;
    public float GetTimeLeft()
    {
        var timeSpan = System.TimeSpan.FromSeconds(m_timeLimit - Time.time);
        return Mathf.Max(0.0f, (float)timeSpan.TotalSeconds);
    }

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    public void SetData(Order order, string text, float timeLimit, float reward)
    {
        Order = order;
        m_timeLimit = timeLimit;
        m_textLabel.text = text;
        m_rewardLabel.text = string.Format("${0:0.00}", reward);
    }

    void Update()
    {
        var timeSpan = System.TimeSpan.FromSeconds(m_timeLimit - Time.time);
        if (timeSpan.TotalSeconds > 0)
            m_timeLabel.text = string.Format("{0}:{1}", timeSpan.Minutes.ToString("D2"), timeSpan.Seconds.ToString("D2"));
        else
            m_timeLabel.text = "00:00";

        if (timeSpan.TotalSeconds < 10.0f)
            m_bg.color = m_criticalColor;
        else if (timeSpan.TotalSeconds < 15.0f)
            m_bg.color = m_warningColor;
        else
            m_bg.color = m_normalColor;
    }

    public void Anim_Finished()
    {
        if (AnimationFinished != null)
            AnimationFinished(this);
    }

    public void Complete(bool success)
    {
        if (success)
            m_animator.Play("OrderViewSuccess", 0, 0.0f);
        else
            m_animator.Play("OrderViewFail", 0, 0.0f);
    }
}
