using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectScript : MonoBehaviour {
    public Image[] icons;
    public int player;
    public int currentImage;
    public LevelManager manager;
    public GameObject InstructionText, ReadyText;

    // Use this for initialization
    void Start () {
        icons = GetComponentsInChildren<Image>();
        currentImage = 0;

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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.SetInt("P1_Weapon", currentImage);
            manager.P1Ready = true;
            ReadyText.SetActive(true);
            InstructionText.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerPrefs.SetInt("P1_Weapon", -1);
            manager.P1Ready = false;
            ReadyText.SetActive(false);
            InstructionText.SetActive(true);
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
    }
}
