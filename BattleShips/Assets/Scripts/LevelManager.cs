using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public bool P1Ready, P2Ready;
    // Use this for initialization
    void Start () {

        P1Ready = false;
        P2Ready = false;

    }

// Update is called once per frame
void Update () {
        if (P1Ready && P2Ready)
        {
            SceneManager.LoadScene("Scene001");
        }
    }
}
