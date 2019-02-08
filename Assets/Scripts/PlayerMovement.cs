﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 3f;
    public Camera cam;
    public GameObject player;

    public bool isMoving;
    public bool isRolling;

    public Animation anim;
    public Animator playanim;

    // Use this for initialization
    void Start()
    {
        playanim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Roll();
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) )
        {
            isMoving = true;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            isMoving = false;
        }
        if (isMoving == true)
        {
            playanim.Play("RunForwards");
        }


        //Move Forward and back along z axis                           
        transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * moveSpeed);

        //Move Left and right along x Axis                               
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveSpeed);

        //Rotate the player so that forward is the way the camera is facing
        transform.eulerAngles = new Vector3(0, cam.transform.eulerAngles.y, 0);
        
    }

    private void Roll()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = false;
        }
        StartCoroutine("RollAnim");
    }

    IEnumerator RollAnim()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveSpeed = 12f;
            isRolling = true;
            playanim.Play("RollForwards");
            yield return new WaitForSecondsRealtime(0.5f);
            moveSpeed = 6f;
        }
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