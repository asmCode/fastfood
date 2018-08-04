using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    private const float G = -9.8f;
    private static readonly Vector3 Gravity = new Vector3(0, G, 0);
    private Vector3 m_velocity;
    private Vector3 m_axis;
    private float angle;
    private float angleSpeed;

    void Start()
    {
        m_axis = Random.onUnitSphere;
        angleSpeed = Random.Range(100.0f, 600.0f);
    }

    void FixedUpdate()
    {
        m_velocity += Gravity * Time.fixedDeltaTime * 0.8f;

        var position = transform.position;
        position += m_velocity * Time.fixedDeltaTime;
        transform.position = position;

        transform.rotation = transform.rotation * Quaternion.AngleAxis(angleSpeed * Time.fixedDeltaTime, m_axis);
    }

    public void SetVelocity(Vector3 velocity)
    {
        m_velocity = velocity;
    }
}
