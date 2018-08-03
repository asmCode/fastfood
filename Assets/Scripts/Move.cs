using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    private Vector3 m_destinationPosition;
    private Quaternion m_destinationRotation;
  
    private float m_timeVelocity;
    private float m_time;
    private System.Action<Move> m_moveCompleted;

    public bool Finished
    {
        get;
        private set;
    }

    public Transform MovingObject
    {
        get;
        private set;
    }


    public Move(Vector3 destinationPosition, Quaternion destinationRotation, Transform movingObject, System.Action<Move> moveCompleted = null)
    {
        m_destinationPosition = destinationPosition;
        m_destinationRotation = destinationRotation;
        MovingObject = movingObject;
        m_moveCompleted = moveCompleted;
    }

    public void Update()
    {
        if (Finished)
            return;

        m_time = Mathf.SmoothDamp(m_time, 1.0f, ref m_timeVelocity, 0.4f);
        if (Mathf.Abs(m_time - 1.0f) < 0.3f)
            m_time = 1.0f;

        MovingObject.localPosition = Vector3.Lerp(MovingObject.localPosition, m_destinationPosition, m_time);
        MovingObject.localRotation = Quaternion.Slerp(MovingObject.localRotation, m_destinationRotation, m_time);

        Finished = m_time == 1.0f;
    }

    internal void NotifyMoveFinished()
    {
        if (m_moveCompleted != null)
            m_moveCompleted(this);
    }
}
