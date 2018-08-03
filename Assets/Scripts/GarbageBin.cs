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
            m_dropVelocity -= 1.8f * Time.deltaTime;
            var position = m_trash.transform.position;
            position.y += m_dropVelocity * Time.deltaTime;
            m_trash.transform.position = position;

            if (position.y < m_destroyLimit.position.y)
                Destroy(m_trash);
        }
    }

    public void Touched()
    {
        m_animator.SetTrigger("Open");
        m_closed = false;

        m_trashPlaceholder.rotation = Random.rotation;
        Cook.Get().DropRightHand(m_trashPlaceholder, (move) =>
        {
            m_trash = move.MovingObject.gameObject;
            m_dropVelocity = 0.0f;
        });
    }
}
