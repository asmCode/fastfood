using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfBan : MonoBehaviour
{
    public Material m_rawMaterial;
    public Material m_doneMaterial;

    private Renderer m_renderer;

    public HalfBanCookStatus HalfBanCookStatus
    {
        get;
        private set;
    }

    public void SetHalfBanCookStatus(HalfBanCookStatus status)
    {
        HalfBanCookStatus = status;

        UpdateModel();
    }

    private void UpdateModel()
    {
        Material material = null;

        switch (HalfBanCookStatus)
        {
            case HalfBanCookStatus.Raw:
                material = m_rawMaterial;
                break;

            case HalfBanCookStatus.Done:
                material = m_doneMaterial;
                break;
        }

        m_renderer.material = material;
    }

    private void Awake()
    {
        m_renderer = transform.Find("Model").GetComponent<Renderer>();

        SetHalfBanCookStatus(HalfBanCookStatus.Raw);
    }
}
