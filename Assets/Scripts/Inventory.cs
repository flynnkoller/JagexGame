using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public GameObject inventory;
    public bool invOpen;
    public static Inventory instance;

    public int space = 6;


    void Start()
    {
        inventory.SetActive(false);
        invOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inventory.activeInHierarchy == true) // check to see if inv is open already
        {
            invOpen = true;
        }
        if (inventory.activeInHierarchy == false)
        {
            invOpen = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (invOpen == false)
            {
                inventory.SetActive(true);
            }

            if (invOpen == true)
            {
                inventory.SetActive(false);
            }

        }
    }
}
