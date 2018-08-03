using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook : MonoBehaviour
{
    private static Cook m_instance;

    public Transform m_camera;
    public Transform m_leftHand;
    public Transform m_rightHand;

    public Inventory Inventory
    {
        get;
        set;
    }

    public Cook()
    {
        Inventory = new Inventory();
    }

    public void DropRightHand()
    {
        Inventory.SetRightHand(null);

        if (m_rightHand.childCount == 0)
            return;

        m_rightHand.GetChild(0).SetParent(null);
    }

    public void DropRightHand(Transform parent, System.Action<Move> moveCompleted = null)
    {
        Inventory.SetRightHand(null);

        if (m_rightHand.childCount == 0)
            return;

        Mover.Get().Move(m_rightHand.GetChild(0), parent, moveCompleted);

        // Utils.SetParentAndResetTransform(m_rightHand.GetChild(0), parent);
    }

    public void DropLeftHand()
    {

    }

    public void GrabRightHand(GameObject gameObject)
    {
        if (!Inventory.IsRightHandFree)
            return;

        Inventory.SetRightHand(gameObject);

        Mover.Get().Move(gameObject.transform, m_rightHand);

        //gameObject.transform.SetParent(m_rightHand);
        //gameObject.transform.localPosition = Vector3.zero;
        //gameObject.transform.localRotation = Quaternion.identity;
        //gameObject.transform.localScale = Vector3.one;
    }

    public bool IsHolding<T>()
    {
        return Inventory.RightHand != null && Inventory.RightHand.GetComponent<T>() != null;
    }

    public T GetRightHand<T>() where T : Component
    {
        if (Inventory.RightHand == null)
            return null;
        
        return Inventory.RightHand.GetComponent<T>();
    }

    public void GrabLeftHand(GameObject gameObject)
    {

    }

    public static Cook Get()
    {
        if (m_instance == null)
            m_instance = GameObject.Find("Cook").GetComponent<Cook>();

        return m_instance;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var hits = Physics.RaycastAll(m_camera.transform.position, m_camera.transform.forward, 100.0f);

            if (hits.Length > 0)
            {
                System.Array.Sort(hits, (a, b) => { return a.distance.CompareTo(b.distance); });

                for (int i = 0; i < hits.Length; i++)
                {
                    var interactiveElement = hits[i].transform.GetComponent<BaseInteractiveElement>();

                    if (interactiveElement == null)
                        continue;

                    if (interactiveElement.gameObject == Inventory.RightHand)
                        break;

                    interactiveElement.DoAction();
                    break;
                }
            }
        }
    }
}
