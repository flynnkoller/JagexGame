using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private float _moveSpeed = 3f;
    public Camera cam;
    public GameObject player;
    public GameObject prompt;

    public bool isMoving;
    public bool isRolling;

    public Animation anim;
    public Animator playanim;

    public Interactable focus;

    // Use this for initialization
    void Start()
    {
        playanim = gameObject.GetComponent<Animator>();
        prompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Roll();
        ItemHit();
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
        transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * _moveSpeed);

        //Move Left and right along x Axis                               
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * _moveSpeed);

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

    //Double move speed - play the roll animation and start a time to wait - return back to default speed
    IEnumerator RollAnim()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _moveSpeed = 12f;
            isRolling = true;
            playanim.Play("RollForwards");
            yield return new WaitForSecondsRealtime(0.5f);
            _moveSpeed = 6f;
        }
    }

    private void ItemHit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //if it hits
            if (Physics.Raycast(ray, out hit, 100))
            {
                RemoveFocus();
            }

        }



        if (Input.GetMouseButtonDown(1)) //right mouse
        {
            //create a ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //if it hits
            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        focus = newFocus;
    }

    void RemoveFocus()
    {
        focus = null;
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
        if (other.tag == "Pond")
        {
            prompt.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Pond")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                prompt.SetActive(false);
                SceneManager.LoadScene("FishingMinigame");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Pond")
        {
            prompt.SetActive(false);
        }
    }


}