using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Function for just the spreadshot weapon and its behavior
public class SpreadShotBehavior : MonoBehaviour {

    public GameObject LaunchPoint;
    public CannonballBehavior cannonball, cannonball2;
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
        Vector3 rotation = LaunchPoint.transform.rotation.eulerAngles;
        rotation.y += 45;
        Quaternion q = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        cannonball.bouncesToLive = 3;
        Instantiate(cannonball, LaunchPoint.transform.position + LaunchPoint.transform.right * 20, q);

        rotation.y -= 90;
        q = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        cannonball2.bouncesToLive = 3;
        Instantiate(cannonball2, LaunchPoint.transform.position - LaunchPoint.transform.right * 20, q);

        GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired = true;

        fireSource.Play();
    }
}
