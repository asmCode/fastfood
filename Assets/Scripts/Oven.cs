using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    private Animator m_animator;

    private bool m_isCooking;
    private float m_timer;
    private Transform m_dropables;

    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_dropables = transform.Find("Dropables");
    }

    void Start()
    {

    }

    void Update()
    {
        if (m_isCooking)
        {
            m_timer -= Time.deltaTime;
            if (m_timer <= 0.0f)
            {
                StopCooking();
            }
        }
    }

    public void PressStartButton()
    {
        m_animator.Play("OvenClose", 0, 0.0f);

        m_isCooking = true;
        m_timer = 8.0f;
    }

    public void PressStopAlarmButton()
    {

    }

    private void StopCooking()
    {
        m_isCooking = false;

        m_animator.Play("OvenOpen", 0, 0.0f);

        for (int i = 0; i < m_dropables.childCount; i++)
        {
            var drop_area = m_dropables.GetChild(i);
            if (drop_area.childCount == 0)
                continue;

            var beef = drop_area.GetComponentInChildren<Beef>();
            if (beef == null)
                continue;

            beef.SetBeefType(BeefType.Done);
        }
    }
}
