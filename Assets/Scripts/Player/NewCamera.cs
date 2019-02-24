using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCamera : MonoBehaviour {

    //Camera possitions
    private float _currentX;
    private float _currentY;

    //Camera constraints
    private const float _YangleMin = -45.0f;
    private const float _YangleMax = 50.0f;

    //Camera colliosion stuff
    private bool _onWall;
    private Vector3 _colDir;

    //The direction the camera is facing
    private Vector3 _dir;

    //Objects that we need
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
        CamPos();
        Mouse();
        CamRotate();
        CamRay(firePoint.transform.position);
    }

    void Mouse()
    {
        //Lock the cursor and make it invisible 
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Sets the position of the camera around the player as a pivot
    void CamPos()
    {
        //Get the axis of where the mouse is
        _currentX += Input.GetAxis("Mouse X");
        _currentY += -Input.GetAxis("Mouse Y");


        //REDO !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        if(_onWall == true)
        {
            _currentX += _colDir.x;
            _currentY += _colDir.y;
        }

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
        transform.position += new Vector3(0, 2, 0);
    }

    void CamRotate()
    {
        //Looks at the player transform + an offset to give a more over shoulder feel
        transform.LookAt(player.transform.position + new Vector3(.5f, 2, .5f));
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

    //REDO !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "wall")
        {
            _onWall = true;

            //Gets the direction that the collision happened 
            _colDir = (col.contacts[0].point);
        }
    }

    void OnCollisionExit(Collision col)
    {
        _onWall = false;
        _colDir = Vector3.zero;
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
