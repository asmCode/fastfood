using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBin : MonoBehaviour
{
    private Animator m_animator;
    private bool m_closed = true;
    private Transform m_trashPlaceholder;
    private Transform m_destroyLimit;
    private GameObject m_trash;

    private float m_dropVelocity;

    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_trashPlaceholder = transform.Find("TrashPlaceholder");
        m_destroyLimit = transform.Find("DestroyLimit");
    }

    void Update()
    {
        if (m_trash != null)
        {
            var position = m_trash.transform.position;

            if (position.y < m_destroyLimit.position.y)
                Destroy(m_trash);
        }
    }

    public void Touched()
    {
        m_animator.SetTrigger("Open");
        m_closed = false;

        m_trashPlaceholder.rotation = Random.rotation;

        var cook = Cook.Get();

        var obj = cook.Inventory.RightHand;
        if (obj == null)
            return;

        obj.transform.SetParent(null);
        cook.Inventory.SetRightHand(null);

        var dir = m_trashPlaceholder.position - obj.transform.position;
        dir.Normalize();
        dir.y += 1.0f;

        var thrower = obj.AddComponent<Thrower>();
        thrower.SetVelocity(dir * 1.2f);

        m_trash = obj;
    }
}
