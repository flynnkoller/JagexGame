
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    private const float _YangleMin = 0.0f;
    private const float _YangleMax = 50.0f;
    float offset = -3;

    public Transform lookAt;
    public Transform cameraTransform;
    private Transform _pivot;

    private Camera _camera;

    private float _distance = 5.0f;
    private float _currentX = 0.0f;
    private float _currentY = 0.0f;
    private float _sensitivityX = 4.0f;
    private float _sensitivityY = 1.0f;

    [SerializeField]
    private bool _moveEnable = true;

    LayerMask mask;

    private void OnEnable()
    {
        mask = 1 << LayerMask.NameToLayer("Clippable") | 0 << LayerMask.NameToLayer("NotClippable");
        _pivot = transform;
    }

    private void Start()
    {
        cameraTransform = transform;
        _camera = Camera.main;
    }

    private void Update()
    {
        if(_moveEnable == true)
        {
            CameraPosition();
        } else if(Distance(cameraTransform, lookAt) >= 6)
        {
            _moveEnable = true;
        }

        Debug.Log(Distance(cameraTransform, lookAt));
    }

    private void LateUpdate()
    {
        if(_moveEnable == true)
        {
            CameraRotation();
        }
         else if(Distance(cameraTransform, lookAt) >= 6)
        {
            _moveEnable = true;
        }

    }

    void CameraPosition()
    {
        //The position around a pivot
        _currentX += Input.GetAxis("Mouse X");
        _currentY += -Input.GetAxis("Mouse Y");
        _currentY = Mathf.Clamp(_currentY, _YangleMin, _YangleMax);

        //central ray
        float unobstructed = offset;  // <- why???
        Vector3 idealPostion = _pivot.TransformPoint(Vector3.forward * offset);
    }

    void CameraRotation()
    {
        //The rotation based on position and player pos
        Vector3 dir = new Vector3(0, 0, -_distance);
        Quaternion rotation = Quaternion.Euler(_currentY, _currentX, 0);
        cameraTransform.position = lookAt.position + rotation * dir;
        cameraTransform.LookAt(lookAt.position);
    }

    //Can't escape the wall - need a check to release ie. distance check
    private void OnCollisionStay(Collision collision)
    {
        //Works on the back and front but not the side walls???
        if (collision.gameObject.tag.Equals("wall") && Distance(cameraTransform, lookAt) < 5.5f)
        {
            _moveEnable = false;
        }
        else if(Distance(cameraTransform, lookAt) >= 5.5f)
        {
            _moveEnable = true;
        }
    }

    //Should probably move this to a public function access somewhere as it'll be used more
    float Distance(Transform start, Transform end)
    {
        var x = Mathf.Pow((start.position.x - end.position.x), 2);
        var y = Mathf.Pow((start.position.y - end.position.y), 2);
        var z = Mathf.Pow((start.position.z - end.position.z), 2);

        var c = Mathf.Sqrt(x + y + z);
        return c;
    }
}
