using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ControlSwitcherPractice : MonoBehaviour
{

	public float timeSwitch, timeLeft;
	public GameObject Boat1, Boat2, P1Aim, P2Aim, wall;
	public Canvas UI;
	public RawImage P1Ind, P2Ind;
	public int activePlayer, cannonCounter;
	public bool playerFired = false;
	public bool gameIsOver = false;

	public GameObject timer, gameover;

	// Use this for initialization
	void Awake ()
	{
		timeSwitch = 20;
		timeLeft = timeSwitch;
		activePlayer = 1;
		P2Aim.SetActive (false);
		P1Aim.SetActive (true); 
		cannonCounter = 0;
		if(!PlayerPrefs.HasKey("firstTime")){
			PlayerPrefs.SetInt("firstTime", 0);
		}
		if (PlayerPrefs.GetInt ("firstTime") == 1) {
			DestroyImmediate (wall.gameObject);
		}
		PlayerPrefs.SetInt("firstTime", 1);
		PlayerPrefs.Save();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{

		if (gameIsOver) {
			if (Input.GetKeyDown ("space")) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
            
		}
        

		if (!playerFired) {
			//timeLeft = timeLeft - Time.fixedDeltaTime;
		} else {
			P1Aim.SetActive (false);
			P2Aim.SetActive (false);
		}
        
		if (!Boat1.activeInHierarchy) {
			gameover.GetComponent<Text> ().text = "STOP KILLING YOURSELF";
			gameover.SetActive (true);
			gameIsOver = true;
		} else if (!Boat2.activeInHierarchy) {
			gameover.GetComponent<Text> ().text = "TARGET ELIMINATED";
			gameover.SetActive (true);
			gameIsOver = true;
		}


		//Switch players every so often
		if (timeLeft <= 0 || cannonCounter >= 2) {
			timeLeft = timeSwitch;
			cannonCounter = 0;
			playerFired = false;

			P1Ind.enabled = true;
			P2Ind.enabled = false;
			Boat1.GetComponent<PracticeController> ().enabled = (true);
			P2Aim.SetActive (false);
			P1Aim.SetActive (true);

		}

		timer.GetComponent<Text> ().text = "TIME LEFT: Infinite";
	}
}
