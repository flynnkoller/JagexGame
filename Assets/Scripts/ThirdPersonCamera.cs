
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    private const float YangleMin = 0.0f;
    private const float YangleMax = 50.0f;
    float offset = -3;

    public Transform lookAt;
    public Transform cameraTransform;
    Transform pivot;

    private Camera camera;

    private float distance = 5.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;

    LayerMask mask;

    private void OnEnable()
    {
        mask = 1 << LayerMask.NameToLayer("Clippable") | 0 << LayerMask.NameToLayer("NotClippable");
        pivot = transform;
    }

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

        //central ray
        float unobstructed = offset;
        Vector3 idealPostion = pivot.TransformPoint(Vector3.forward * offset);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        cameraTransform.position = lookAt.position + rotation * dir;
        cameraTransform.LookAt(lookAt.position);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag.Equals("wall"))
        {
            this.enabled = false;
        }
        else
        {
            this.enabled = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        this.enabled = true;
    }


}
