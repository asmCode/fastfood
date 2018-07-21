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

    public int OrderId
    {
        get;
        private set;
    }

    public Color m_normalColor;
    public Color m_warningColor;
    public Color m_criticalColor;

    private float m_timeLimit;
    private Order m_order;

    public void SetData(Order order, int orderId, string text, float timeLimit, float reward)
    {
        m_order = order;
        OrderId = orderId;
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

        if (timeSpan.TotalSeconds < 20.0f)
            m_bg.color = m_criticalColor;
        else if (timeSpan.TotalSeconds < 40.0f)
            m_bg.color = m_warningColor;
        else
            m_bg.color = m_normalColor;
    }
}
