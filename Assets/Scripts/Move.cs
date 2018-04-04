using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    private Vector3 m_destinationPosition;
    private Quaternion m_destinationRotation;
    private Transform m_movingObject;

    private float m_timeVelocity;
    private float m_time;

    public bool Finished
    {
        get;
        private set;
    }
 
    public Move(Vector3 destinationPosition, Quaternion destinationRotation, Transform movingObject)
    {
        m_destinationPosition = destinationPosition;
        m_destinationRotation = destinationRotation;
        m_movingObject = movingObject;
    }

    public void Update()
    {
        if (Finished)
            return;

        m_time = Mathf.SmoothDamp(m_time, 1.0f, ref m_timeVelocity, 0.4f);
        if (Mathf.Abs(m_time - 1.0f) < 0.1f)
            m_time = 1.0f;

        m_movingObject.localPosition = Vector3.Lerp(m_movingObject.localPosition, m_destinationPosition, m_time);
        m_movingObject.localRotation = Quaternion.Slerp(m_movingObject.localRotation, m_destinationRotation, m_time);

        Finished = m_time == 1.0f;
    }
}
