using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheildGunBehavior : MonoBehaviour {

    public GameObject LaunchPoint;
    public GameObject shield;
    public AudioSource fireSource;
    public bool HasShield;


    // Use this for initialization
    void Start () {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("LaunchPoint"))
            {
                LaunchPoint = child.gameObject;
            }
        }


        fireSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame

        //Still doesn't work, the limiting
	void Update () {
        if (this.gameObject.name == "Boat")
        {
            if (this.transform.parent.Find("Shield"))
            {
                HasShield = true;
            }
            else
            {
                HasShield = false;
            }
        }
        else if (this.gameObject.name == "Boat2")
        {
            if (GameObject.Find("Shield2"))
            {
                HasShield = true;
            }
            else
            {
                HasShield = false;
            }
        }

    }


    public void Fire()
    {

        if (!HasShield)
        {
            if (this.gameObject.name == "Boat")
            {
                Instantiate(shield, LaunchPoint.transform.position + new Vector3(0f, 0f, 30f), LaunchPoint.transform.rotation);

            }
            else if (this.gameObject.name == "Boat2")
            {
                Instantiate(shield, LaunchPoint.transform.position + new Vector3(0f, 0f, -30f), LaunchPoint.transform.rotation);
            }

            fireSource.Play();


            GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired = true;
            GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().cannonCounter = 2;
        }
        else
        {
            //some kind of audio or visual warning to player that they're limited to one active shield;
        }
        
    }
}
