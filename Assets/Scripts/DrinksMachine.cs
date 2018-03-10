using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinksMachine : MonoBehaviour
{
    private GameObject m_stream;
    private Material m_streamMaterial;
    private bool m_isWorking;

    private void Awake()
    {
        m_stream = transform.Find("DrinkStream").gameObject;
        m_streamMaterial = m_stream.GetComponent<Renderer>().material;

        m_stream.SetActive(false);
    }

    void Update()
    {
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

        m_isWorking = true;

        Invoke("StopWorking", 2.0f);
    }

    private void StopWorking()
    {
        if (!m_isWorking)
            return;

        m_stream.SetActive(false);

        m_isWorking = false;
    }
}
