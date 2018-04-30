using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubWeaponSelect : MonoBehaviour {
    
    public Image[] icons;
    public int player;
    public int currentImage;
    public LevelManager manager;
    public GameObject InstructionText, ReadyText;


    // Use this for initialization
    void Start () {
        icons = GetComponentsInChildren<Image>();
        currentImage = 0;

        PlayerPrefs.SetInt("P1_Weapon", -1);
        PlayerPrefs.SetInt("P2_Weapon", -1);

        manager = FindObjectOfType<LevelManager>();

        
        ReadyText.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (player == 0)
        {
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
        }
        else if (player == 1)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                currentImage--;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                currentImage++;
            }
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                PlayerPrefs.SetInt("P2_Weapon", currentImage);
                manager.P2Ready = true;
                ReadyText.SetActive(true);
                InstructionText.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                PlayerPrefs.SetInt("P2_Weapon", -1);
                manager.P2Ready = false;
                ReadyText.SetActive(false);
                InstructionText.SetActive(true);

            }
        }

        if (currentImage < 0)
        {
            currentImage = 3;
        }
        
        else if (currentImage > 3)
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
