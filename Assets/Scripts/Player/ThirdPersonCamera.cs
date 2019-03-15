
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    private float _currentX;
    private float _currentY;

    private const float _YangleMin = 0.0f;
    private const float _YangleMax = 50.0f;

    private Vector3 _dir;

    public GameObject player;
    public GameObject firePoint;
    private Camera _cam;

    // Use this for initialization
    void Start()
    {
        _cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        AvoidWall();
        //Mouse();
        CamPos();
        CamRotate();
        CamRay(firePoint.transform.position);
    }

    void Mouse()
    {
        //Lock the cursor and make it invisible 
        Cursor.lockState = CursorLockMode.Locked;
    }

    void CamPos()
    {
        //Get the axis of where the mouse is
        _currentX += Input.GetAxis("Mouse X");
        _currentY += -Input.GetAxis("Mouse Y");

        //Limit the Y axis rotation
        _currentY = Mathf.Clamp(_currentY, _YangleMin, _YangleMax);

        //Set the ideal distance between camera and player
        Vector3 idealPostion = transform.TransformPoint(Vector3.forward * 3);

        //Get the direction of the camera to player
        Vector3 dir = new Vector3(0, 0, -3);

        //
        Quaternion rotation = Quaternion.Euler(_currentY, _currentX, 0);

        //set the postition to the rotation pivot and players by the distance
        transform.position = (player.transform.position) + rotation * dir;

        //Set it so the camera is always above the player
        //transform.position += new Vector3(0, 1, 0);
    }

    void CamRotate()
    {
        //Looks at the player transform
        transform.LookAt(player.transform.position + new Vector3(0.5f, 0, 0.5f));
    }

    void CamRay(Vector3 origin)
    {
        Ray ray = _cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            //Get the direction between the hit point and player so that an arrow can be spawned at that angle
            Dir = hit.point - origin;
        }
        else
        {
            //Compare between the point 10 units down the ray
            Dir = ray.GetPoint(10) - origin;
        }
    }

    void AvoidWall()
    {
        //Using colliders didn't really work
        //Raycasts can work

        Ray ray1 = new Ray(transform.position, Vector3.forward);
        Ray ray2 = new Ray(transform.position, Vector3.back);
        Ray ray3 = new Ray(transform.position, Vector3.left);
        Ray ray4 = new Ray(transform.position, Vector3.right);

        RaycastHit hit;

        if (Physics.Raycast(ray1, out hit, .5f))
        {
            //Stop from moving this way
            _currentX += hit.point.x;
            _currentY += hit.point.y;
        }

        if (Physics.Raycast(ray2, out hit, .5f))
        {
            //Stop from moving this way
            _currentX -= hit.point.x;
            _currentY -= hit.point.y;
        }

        if (Physics.Raycast(ray3, out hit, .5f))
        {
            //Stop from moving this way
            _currentX += hit.point.x;
            _currentY += hit.point.y;
        }

        if (Physics.Raycast(ray4, out hit, .5f))
        {
            //Stop from moving this way
            _currentX -= hit.point.x;
            _currentY -= hit.point.y;
        }
    }

    #region CONSTRUCTORS

    public Vector3 Dir
    {
        get
        {
            return _dir;
        }
        private set
        {
            _dir = value;
        }
    }

    #endregion
}
