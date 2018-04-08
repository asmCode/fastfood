using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster : MonoBehaviour
{
    private Transform m_bottomBanHolder;
    private Transform m_topBanHolder;
    private Animator m_animator;

    private bool m_isCooking;

    public void DoAction()
    {
        var cook = Cook.Get();
        var objectFactory = ObjectFactory.Get();

        if (IsOccupied())
        {
            var bottomBan = GetBottomBan();
            if (bottomBan != null && bottomBan.HalfBanCookStatus == HalfBanCookStatus.Done)
                cook.GrabRightHand(bottomBan.gameObject);
            else
            {
                var topBan = GetTopBan();
                if (topBan != null && topBan.HalfBanCookStatus == HalfBanCookStatus.Done)
                    cook.GrabRightHand(topBan.gameObject);
            }
        }
        else
        {
            if (!cook.Inventory.IsRightHandFree)
            {
                var ban = cook.Inventory.RightHand.GetComponent<Ban>();
                if (ban != null)
                {
                    cook.DropRightHand();
                    Destroy(ban.gameObject);

                    var banBottom = objectFactory.CreateHalfBanBottom();
                    // Utils.SetParentAndResetTransform(banBottom.transform, m_bottomBanHolder);
                    banBottom.transform.position = ban.m_bottomBan.position;
                    banBottom.transform.rotation = ban.m_bottomBan.rotation;
                    Mover.Get().Move(banBottom.transform, m_bottomBanHolder);

                    var banTop = objectFactory.CreateHalfBanTop();
                    // Utils.SetParentAndResetTransform(banTop.transform, m_topBanHolder);
                    banTop.transform.position = ban.m_topBan.position;
                    banTop.transform.rotation = ban.m_topBan.rotation;
                    Mover.Get().Move(banTop.transform, m_topBanHolder);
                }
            }
        }
    }

    public void PressStartButton()
    {
        if (m_isCooking)
            return;

        m_isCooking = true;

        m_animator.Play("ToasterStart", 0, 0.0f);

        Invoke("StopCooking", 5.0f);
    }

    void Awake()
    {
        m_bottomBanHolder = transform.Find("BottomBanHolder");
        m_topBanHolder = transform.Find("TopBanHolder");
        m_animator = GetComponent<Animator>();
    }

    void Update()
    {

    }

    public bool IsOccupied()
    {
        return m_bottomBanHolder.childCount > 0 || m_topBanHolder.childCount > 0;
    }

    public HalfBan GetTopBan()
    {
        if (m_topBanHolder.childCount == 0)
            return null;

        return m_topBanHolder.GetComponentInChildren<HalfBan>();
    }

    public HalfBan GetBottomBan()
    {
        if (m_bottomBanHolder.childCount == 0)
            return null;

        return m_bottomBanHolder.GetComponentInChildren<HalfBan>();
    }

    private void StopCooking()
    {
        m_isCooking = false;

        m_animator.Play("ToasterEnd", 0, 0.0f);

        var bottomBan = GetBottomBan();
        if (bottomBan != null)
            bottomBan.SetHalfBanCookStatus(HalfBanCookStatus.Done);

        var topBan = GetTopBan();
        if (topBan != null)
            topBan.SetHalfBanCookStatus(HalfBanCookStatus.Done);
    }
}
