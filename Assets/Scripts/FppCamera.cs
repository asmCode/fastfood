using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FppCamera : MonoBehaviour
{
    public float m_sensitivity = 0.2f;
    public Transform m_targetCamera;

    private Vector3 m_lastMousePosition;
    private float m_yawAngle;
    private float m_pitchAngle;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        m_lastMousePosition = Input.mousePosition;
    }

    private void Update()
    {
        m_yawAngle += Input.GetAxis("Horizontal") * m_sensitivity;
        m_pitchAngle += Input.GetAxis("Vertical") * m_sensitivity;

        Quaternion yawRotation = Quaternion.AngleAxis(m_yawAngle, Vector3.up);
        Quaternion pitchRotation = Quaternion.AngleAxis(-m_pitchAngle, Vector3.right);

        m_targetCamera.transform.rotation = yawRotation * pitchRotation;
    }
}
