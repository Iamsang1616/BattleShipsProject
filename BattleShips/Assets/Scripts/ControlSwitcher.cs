using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ControlSwitcher : MonoBehaviour {

    public float timeSwitch, timeLeft;
    public GameObject Boat1, Boat2, P1Aim, P2Aim;
    public Canvas UI;
    public RawImage P1Ind, P2Ind;
    public int activePlayer, cannonCounter;
    public bool playerFired = false;
    public bool gameIsOver = false;

    public GameObject timer, gameover;

	// Use this for initialization
	void Start () {
        timeSwitch = 20;
        timeLeft = timeSwitch;
        activePlayer = 1;
        P2Aim.SetActive(false);
        P1Aim.SetActive(true); 
		cannonCounter = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (gameIsOver)
        {
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
        }
        

        if (!playerFired)
        {
            timeLeft = timeLeft - Time.fixedDeltaTime;
        }
        else
        {
            P1Aim.SetActive(false);
            P2Aim.SetActive(false);
        }
        
        if (Boat1.activeInHierarchy == false)
        {
            gameover.GetComponent<Text>().text = "P2 WINS";
            gameover.SetActive(true);
            gameIsOver = true;
        }
        else if (Boat2.activeInHierarchy == false)
        {
            gameover.GetComponent<Text>().text = "P1 WINS";
            gameover.SetActive(true);
            gameIsOver = true;

        }


        //Switch players every so often
        if (timeLeft <= 0||cannonCounter>=2)
        {
            timeLeft = timeSwitch;
			cannonCounter = 0;
			playerFired = false;

            if (activePlayer == 1)
            {
                P1Ind.enabled = false;
                P2Ind.enabled = true;
                Boat1.GetComponent<PlayerController>().enabled = false;
                Boat2.GetComponent<PlayerController>().enabled = true;
                P2Aim.SetActive(true);
                P1Aim.SetActive(false);

                //Any walls stickied by 2 become unsticked at the start of their next turn?
                GameObject[] sticklist = GameObject.FindGameObjectsWithTag("StickyTwo");

                foreach (GameObject g in sticklist)
                {
                    g.tag = "Wall";
                }


                activePlayer = 2;
            }
            else
            {
                P1Ind.enabled = true;
                P2Ind.enabled = false;
                Boat2.GetComponent<PlayerController>().enabled = (false);
                Boat1.GetComponent<PlayerController>().enabled = (true);
                P2Aim.SetActive(false);
                P1Aim.SetActive(true);

                //Any walls stickied by 1 become unsticked at the start of their next turn?
                GameObject[] sticklist = GameObject.FindGameObjectsWithTag("StickyOne");

                foreach (GameObject g in sticklist)
                {
                    g.tag = "Wall";
                }

                activePlayer = 1;
            }

        }

       timer.GetComponent<Text>().text = "TIME LEFT: " + timeLeft.ToString("F2");
	}
}
