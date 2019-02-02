using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 3f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Move Forward and back along z axis                           
        transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * moveSpeed);
        //Move Left and right along x Axis                               
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveSpeed);
    }
}
