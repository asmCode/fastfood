using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sauce : MonoBehaviour
{
    private Material m_material;
    private Animator m_animator;

    void Awake()
    {
        m_animator = GetComponent<Animator>();

        var model = transform.Find("Model").gameObject;
        m_material = model.GetComponent<Renderer>().material;
        m_material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayAppearAnimation()
    {
        m_animator.Play("SauceAppear", 0, 0.0f);
    }
}
