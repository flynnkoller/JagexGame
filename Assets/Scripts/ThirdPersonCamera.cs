using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    private const float YangleMin = 0.0f;
    private const float YangleMax = 50.0f;

    public Transform lookAt;
    public Transform cameraTransform;

    private Camera camera;

    private float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;

    private void Start()
    {
        cameraTransform = transform;
        camera = Camera.main;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += -Input.GetAxis("Mouse Y");
        currentY = Mathf.Clamp(currentY, YangleMin, YangleMax);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        cameraTransform.position = lookAt.position + rotation * dir;
        cameraTransform.LookAt(lookAt.position);
    }
}
