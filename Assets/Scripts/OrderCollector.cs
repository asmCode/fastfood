using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderCollector : MonoBehaviour
{
    private Transform m_trayPlaceholder;

    public void OnTouched()
    {
        if (!HasTray())
        {
            if (Cook.Get().IsHolding<Tray>())
                Cook.Get().DropRightHand(m_trayPlaceholder);

            return;
        }
    }

    void Awake()
    {
        m_trayPlaceholder = transform.Find("TrayPlaceholder");
    }

    private bool HasTray()
    {
        return m_trayPlaceholder.GetComponentInChildren<Tray>() != null;
    }

    public void DispatchOrder()
    {
        if (!HasTray())
            return;

        Destroy(m_trayPlaceholder.GetChild(0).gameObject);
    }
}
