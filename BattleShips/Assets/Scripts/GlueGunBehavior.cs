using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueGunBehavior : MonoBehaviour
{

    public GameObject LaunchPoint;
    public GlueBallBehavior glueBall;
    public AudioSource fireSource;

    // Use this for initialization
    void Start()
    {
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
    void Update()
    {

    }

    public void Fire()
    {
        glueBall.dir = Vector3.forward;
        glueBall.bouncesToLive = 1;
        Instantiate(glueBall, LaunchPoint.transform.position, LaunchPoint.transform.rotation);

        
        GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired = true;
        GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().cannonCounter++;

        fireSource.Play();  
    }
}
