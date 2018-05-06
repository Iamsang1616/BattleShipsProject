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
    public PlayerController pc1, pc2;
    public GameObject timer, gameover;

	// Use this for initialization
	void Start () {
        timeSwitch = 20;
        timeLeft = timeSwitch;
        activePlayer = 1;
        P2Aim.SetActive(false);
        P1Aim.SetActive(true); 
		cannonCounter = 0;

        pc1 = Boat1.GetComponent<PlayerController>();
        pc2 = Boat2.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (gameIsOver)
        {
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
			{
				SceneManager.LoadScene("SubWeaponMenu");
			}
            
        }
        

        if (playerFired && timeLeft > 0)
        {
            timeLeft = timeLeft - Time.fixedDeltaTime;
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
        if (timeLeft <= 0) //||cannonCounter>=2)
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

                pc1.moveSpeed = 90f;

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
                    Renderer rend = g.GetComponent<Renderer>();
                    Material mat;

                    //if boundary wall
                    if (g.GetComponent<MeshCollider>() != null)
                    {
                        mat = Resources.Load("BoundaryWalls", typeof(Material)) as Material;

                    }
                    //if not breakable anyway
                    else if (g.GetComponent<DestructBehavior>() == null || !(g.GetComponent<DestructBehavior>().isActiveAndEnabled))
                    {
                        mat = Resources.Load("Unbreakable", typeof(Material)) as Material;
                       
                    }
                    //if breakable
                    else 
                    {
                       mat = Resources.Load("Breakable", typeof(Material)) as Material;
                        
                    }

                    rend.material = mat;
                }

                pc2.moveSpeed = 90f;

                activePlayer = 1;
            }

        }

       timer.GetComponent<Text>().text = "TIME LEFT: " + timeLeft.ToString("F2");
	}
}
