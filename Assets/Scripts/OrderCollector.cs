using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderCollector : MonoBehaviour
{
    private Transform m_trayPlaceholder;
    private AnimationHelper m_trayPlaceholderAnimationHelper;

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
        m_trayPlaceholderAnimationHelper = m_trayPlaceholder.GetComponent<AnimationHelper>();
    }

    private bool HasTray()
    {
        return m_trayPlaceholder.GetComponentInChildren<Tray>() != null;
    }

    public void DispatchOrder()
    {
        if (!HasTray())
            return;

        m_trayPlaceholderAnimationHelper.Play("TrayGiveAway", () =>
        {
            Destroy(m_trayPlaceholder.GetChild(0).gameObject);
        });

    }
}
