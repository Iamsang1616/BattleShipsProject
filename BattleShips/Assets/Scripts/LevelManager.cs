using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public bool P1Ready, P2Ready, TrainingMode;
    public GameObject TrainText;

    // Use this for initialization
    void Start () {

        P1Ready = false;
        P2Ready = false;
        TrainingMode = false;
        TrainText.SetActive(false);

    }

// Update is called once per frame
void Update () {


        if (P1Ready && P2Ready)
        {
            if (TrainingMode)
            {
				PlayerPrefs.SetInt("firstTime", 0);
                SceneManager.LoadScene("TrainingMode");
            }
            else
            {
                SceneManager.LoadScene("LevelSelect");
            }
        }


        if (Input.GetKeyDown(KeyCode.T) && !TrainingMode)
        {
            TrainingMode = true;
            TrainText.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.T) && TrainingMode)
        {
            TrainingMode = false;
            TrainText.SetActive(false);
        }

    }
}
