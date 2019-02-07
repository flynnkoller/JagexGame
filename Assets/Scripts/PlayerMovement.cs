using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 3f;
    public Camera cam;
    public GameObject player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {

        //Move Forward and back along z axis                           
        transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * moveSpeed);

        //Move Left and right along x Axis                               
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveSpeed);

        //Rotate the player so that forward is the way the camera is facing
        transform.eulerAngles = new Vector3(0, cam.transform.eulerAngles.y, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);

        if (collision.gameObject.tag == "DungeonTrigger1")
        {
            SceneManager.LoadScene("Dungeon1");
        }
        if (collision.gameObject.tag == "HubReturn")
        {
            SceneManager.LoadScene("Hub");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       

    }


}