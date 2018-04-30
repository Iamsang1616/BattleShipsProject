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
                SceneManager.LoadScene("TrainingMode");
            }
            else
            {
                SceneManager.LoadScene("Scene001");
            }
        }


        if (Input.GetKeyDown(KeyCode.T) && !TrainingMode)
        {
            //please execute this line before loading the practice map
            //PlayerPrefs.SetInt("firstTime", 0);
            TrainingMode = true;
            TrainText.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.T) && TrainingMode)
        {
            //please execute this line before loading the practice map
            //PlayerPrefs.SetInt("firstTime", 1);
            TrainingMode = false;
            TrainText.SetActive(false);
        }

    }
}
