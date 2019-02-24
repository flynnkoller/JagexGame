using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Fishing : MonoBehaviour {

    public Text waitText;
    public Text foundText;
    public Text quicktimeText;
    public Text addedToInvText;
    public Text playAgainText;

    public KeyCode kc;

    int ticker;

    bool fishFound;
    bool qteActive;

	// Use this for initialization
	void Start () {

        ticker = 0;

        foundText.enabled = false;
        quicktimeText.enabled = false;
        addedToInvText.enabled = false;
        playAgainText.enabled = false;

        fishFound = false;
        qteActive = false;

        StartCoroutine(Wait());

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Hub");
        }
        

        if (fishFound == false)
        {
            StartCoroutine(TextChange());
        }

        if (fishFound == true)
        {
            QuickTimeCatch();
            fishFound = false;
        }

        //QTE
        if (qteActive == true) 
        {
            Random rnd = new Random();
            int rndAmount = Random.Range(3, 11); //picks a random amount of QTE events


            if (Input.GetKeyDown(kc))
                {
                        QuickTimeCatch();
                        ticker++;
                }

               if (ticker == rndAmount)
               {
                  addedToInvText.enabled = true;
                  quicktimeText.enabled = false;
                  playAgainText.enabled = true;

                  foundText.text = "Fish Caught!";
                
                  playAgainText.text = "Press space to play again or esc to quit!";
                  
                  if (Input.GetKeyDown(KeyCode.Space))
                  {
                    ticker = 0;
                    SceneManager.LoadScene("FishingMinigame");
                  }

               }
        }
        
    }

    IEnumerator TextChange() //waiting text w/ moving ellipses
    {
        do
        {
            waitText.text = "Waiting For A Bite";
            yield return new WaitForSeconds(1);
            waitText.text = "Waiting For A Bite.";
            yield return new WaitForSeconds(1);
            waitText.text = "Waiting For A Bite..";
            yield return new WaitForSeconds(1);
            waitText.text = "Waiting For A Bite...";
            yield return new WaitForSeconds(1);

        } while (fishFound == false);
        
    }

    IEnumerator Wait() //picks a random second and waits that long
    {
        int waitTime = Random.Range(0, 15);
        yield return new WaitForSeconds(waitTime);
        waitText.enabled = false;
        foundText.enabled = true;

        fishFound = true;
    }

    private void QuickTimeCatch() //picks a random letter and displays it to the user
    {
        qteActive = true;
        quicktimeText.enabled = true;
        
            string[] Alphabet = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            string randomLetter = Alphabet[Random.Range(0, Alphabet.Length)];
            quicktimeText.text = "Press " + randomLetter + "!";

            kc = (KeyCode)System.Enum.Parse(typeof(KeyCode), randomLetter);
        
            
    }



}
