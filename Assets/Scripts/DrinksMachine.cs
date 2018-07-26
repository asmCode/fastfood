using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinksMachine : MonoBehaviour
{
    private const float Duration = 3.0f;
    private GameObject m_stream;
    private Material m_streamMaterial;
    private Transform m_cupDrop;
    private bool m_isWorking;
    private float m_time;
    private Animator m_animator;
  
    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_stream = transform.Find("DrinkStream").gameObject;
        m_cupDrop = transform.Find("CupDrop");
        m_streamMaterial = m_stream.GetComponent<Renderer>().material;

        m_stream.SetActive(false);
    }

    void Update()
    {
        if (m_isWorking)
        {
            m_time += Time.deltaTime;

            var cup = GetCup();
            if (cup != null)
            {
                cup.SetLevel(Mathf.Clamp01(m_time / Duration));
            }
        }
    }

    public void PushIceButton()
    {
        AddIce();
    }

    private void AddIce()
    {
        var cup = GetCup();
        if (cup != null)
            cup.SetIce(true);

        m_animator.Play("DrinksMachineDropIce", 0, 0);
        m_animator.speed = 1.0f;
    }

    public void AnimEvent_DrinksMachineDropIceFinished()
    {
        m_animator.Play("DrinksMachineDropIce", 0, 0);
        m_animator.speed = 0.0f;
    }

    public void PushCokeButton()
    {
        var cup = GetCup();
        if (cup != null)
            cup.SetDrinkType(ProductType.Coke);

        StartWorking(DrinkColor.GetDrinkColor(ProductType.Coke));
    }

    public void PushOrangeJiuceButton()
    {
        var cup = GetCup();
        if (cup != null)
            cup.SetDrinkType(ProductType.OrangeJuice);

        StartWorking(DrinkColor.GetDrinkColor(ProductType.OrangeJuice));
    }

    public void PushIceTeaButton()
    {
        var cup = GetCup();
        if (cup != null)
            cup.SetDrinkType(ProductType.IceTea);

        StartWorking(DrinkColor.GetDrinkColor(ProductType.IceTea));
    }

    private void StartWorking(Color color)
    {
        if (m_isWorking)
            return;

        m_streamMaterial.color = color;

        m_stream.SetActive(true);

        m_time = 0.0f;
        m_isWorking = true;

        Invoke("StopWorking", Duration);
    }

    private void StopWorking()
    {
        if (!m_isWorking)
            return;

        m_stream.SetActive(false);

        var cup = GetCup();
        if (cup != null)
            cup.SetLevel(1.0f);

        m_isWorking = false;
    }

    private Cup GetCup()
    {
        if (m_cupDrop.childCount == 0)
            return null;

        return m_cupDrop.GetChild(0).GetComponent<Cup>();
    }
}
