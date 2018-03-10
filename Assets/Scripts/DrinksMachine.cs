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

  
    private void Awake()
    {
        m_stream = transform.Find("DrinkStream").gameObject;
        m_cupDrop = transform.Find("CupDrop");
        m_streamMaterial = m_stream.GetComponent<Renderer>().material;

        m_stream.SetActive(false);
    }

    void Update()
    {
        if (m_isWorking)
            m_time += Time.deltaTime;

        var cup = GetCup();
        if (cup != null)
        {
            cup.SetDrinkColor(m_streamMaterial.color);
            cup.SetLevel(Mathf.Clamp01(m_time / Duration));
        }
    }

    public void PushCokeButton()
    {
        StartWorking(Color.black);
    }

    public void PushOrangeJiuceButton()
    {
        StartWorking(new Color32(255, 165, 0, 1));
    }

    public void PushIceTeaButton()
    {
        StartWorking(Color.yellow);
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

        m_isWorking = false;
    }

    private Cup GetCup()
    {
        if (m_cupDrop.childCount == 0)
            return null;

        return m_cupDrop.GetChild(0).GetComponent<Cup>();
    }
}
