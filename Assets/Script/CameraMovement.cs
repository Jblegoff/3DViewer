using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera m_camera;
    [SerializeField] private Transform target;

    private Vector3 previousPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = m_camera.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = previousPosition - m_camera.ScreenToViewportPoint(Input.mousePosition);
            m_camera.transform.position = target.position;
            m_camera.transform.Rotate(new Vector3(1, 0, 0), direction.y* 180);
            m_camera.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180,Space.World);
            m_camera.transform.Translate(new Vector3(0, 0, -2));

            previousPosition = m_camera.ScreenToViewportPoint(Input.mousePosition);
        }
    }
}
