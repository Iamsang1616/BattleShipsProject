using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldgunBehavior : MonoBehaviour {

    public GameObject sheild;
    public GameObject LaunchPoint;
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
        

        fireSource.Play();
    }
}
