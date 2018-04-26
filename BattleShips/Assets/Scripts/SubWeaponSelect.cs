using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SubWeaponSelect : MonoBehaviour {

    public Image[] icons;
    public int player;
    private int currentImage;
    public PlayerController boat; 

	// Use this for initialization
	void Start () {
        icons = GetComponentsInChildren<Image>();
        currentImage = 0;
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
                boat.subWeapon = currentImage;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {

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
                boat.subWeapon = currentImage;
            }
            if (Input.GetKeyDown(KeyCode.RightControl))
            {

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
