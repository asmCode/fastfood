using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beef : MonoBehaviour
{
    public Material m_rawMaterial;
    public Material m_doneMaterial;
    public Material m_burnedMaterial;
    public GameObject m_model;

    private Renderer m_renderer;

    public BeefType BeefType
    {
        get;
        private set;
    }

    public void SetBeefType(BeefType beefType)
    {
        BeefType = beefType;

        UpdateMaterial();
    }

    private void UpdateMaterial()
    {
        Material material = null;

        switch (BeefType)
        {
            case BeefType.Raw:
                material = m_rawMaterial;
                break;

            case BeefType.Done:
                material = m_doneMaterial;
                break;

            case BeefType.Burned:
                material = m_burnedMaterial;
                break;
        }

        m_renderer.material = material;
    }

    private void Awake()
    {
        m_renderer = m_model.GetComponent<Renderer>();

        SetBeefType(BeefType.Raw);
    }
}
