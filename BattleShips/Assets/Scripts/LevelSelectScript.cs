using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour {
    public Image[] icons;
    public int player;
    public int currentImage;
    public bool P1Ready;
    public GameObject InstructionText, ReadyText;

    // Use this for initialization
    void Start () {
        icons = GetComponentsInChildren<Image>();
        currentImage = 0;
        P1Ready = false;

        ReadyText.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentImage--;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            currentImage++;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            P1Ready = true;
            ReadyText.SetActive(true);
            InstructionText.SetActive(false);

        }
        

        if (currentImage < 0)
        {
            currentImage = 5;
        }

        else if (currentImage > 5)
        {
            currentImage = 0;
        }

        foreach (Image i in icons)
        {
            i.gameObject.SetActive(false);
        }

        icons[currentImage].gameObject.SetActive(true);

        if (P1Ready)
        {
            switch (currentImage)
            {
                case 0:
                    SceneManager.LoadScene("Scene001");
                    break;
                case 1:
                    SceneManager.LoadScene("Scene002");
                    break;
                case 2:
                    SceneManager.LoadScene("Scene003");
                    break;
                case 3:
                    SceneManager.LoadScene("Scene004");
                    break;
                case 4:
                    SceneManager.LoadScene("Scene005");
                    break;
                case 5:
                    SceneManager.LoadScene("Scene006");
                    break;
            }
        }

    }
}
