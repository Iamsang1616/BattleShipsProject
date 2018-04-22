using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheildGunBehavior : MonoBehaviour {

    public GameObject LaunchPoint;
    public GameObject shield;
    public AudioSource fireSource;

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
	void Update () {



    }


    public void Fire()
    {
        Instantiate(shield, LaunchPoint.transform.position, LaunchPoint.transform.rotation);
        fireSource.Play();
    }
}
