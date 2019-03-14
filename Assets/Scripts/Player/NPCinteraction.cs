using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPCinteraction : MonoBehaviour {

    public GameObject prompt;
    public GameObject npcConversationUI;

    public Text npcName;
    public Text npcText;

    // Use this for initialization
    void Start () {
        prompt.SetActive(false);
        npcConversationUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wmerchant" || other.tag == "Gmerchant" || other.tag == "fishingGuide" || other.tag == "explorerF" || other.tag == "dog" || other.tag == "questGuide")
        {
            prompt.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        

            if (Input.GetKeyDown(KeyCode.R))
            {
                //Time.timeScale = 0;
                npcConversationUI.SetActive(true);
                if (other.tag == "Wmerchant")
                {
                    npcName.text = "Weapons Merchant";
                    npcText.text = "hewwo";
                        if (Input.GetKeyDown(KeyCode.F))
                        {
                            for (int i = 0; i < 3; i++)
                            {
                            npcText.text = i.ToString();
                            }

                        }
                    
                }
                
            }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wmerchant" || other.tag == "Gmerchant" || other.tag == "fishingGuide" || other.tag == "explorerF" || other.tag == "dog" || other.tag == "questGuide")
        {
            prompt.SetActive(false);
        }
    }
}
