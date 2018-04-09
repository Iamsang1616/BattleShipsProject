﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float rotateSpeed;
    public GameObject cannonball, LaunchPoint;
    public AudioClip fireSound;
    public AudioSource fireSource;

    private Rigidbody myRigidBody;
    private float moveAmount;
    private float rotateAmount;
    


	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody>();
        rotateSpeed = 60f;
        moveSpeed = 70f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        moveAmount = Time.deltaTime * moveSpeed;
        rotateAmount = rotateSpeed * Time.deltaTime;

        //Rotate ships left and right on pressing the buttons
        //Use either WASD or Arrow Keys based on current player
        if (GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().activePlayer == 2)
        {
            

            if (Input.GetKey("left"))
            {
                myRigidBody.transform.Rotate(0, -rotateAmount, 0);
            }
            if (Input.GetKey("right"))
            {
                myRigidBody.transform.Rotate(0, +rotateAmount, 0);
            }
            if (Input.GetKey("up"))
            {
                myRigidBody.transform.Translate(-moveAmount, 0, 0);
            }
            if (Input.GetKey("down"))
            {
                myRigidBody.transform.Translate(+moveAmount, 0, 0);
            }
            //stop all movement once a player fires a cannonball
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                Instantiate(cannonball, LaunchPoint.transform.position,LaunchPoint.transform.rotation);

                this.GetComponent<PlayerController>().enabled = false;
                GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired = true;

                fireSource.Play();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                myRigidBody.transform.Rotate(0, -rotateAmount, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                myRigidBody.transform.Rotate(0, +rotateAmount, 0);
            }
            if (Input.GetKey(KeyCode.W))
            {
                myRigidBody.transform.Translate(-moveAmount, 0, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                myRigidBody.transform.Translate(+moveAmount, 0, 0);
            }
            //Stop all movement once a player fires
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Instantiate(cannonball, LaunchPoint.transform.position, LaunchPoint.transform.rotation);
                
                this.GetComponent<PlayerController>().enabled = false;
                GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired = true;
                
                fireSource.Play();
            }
        }  
    }

}
