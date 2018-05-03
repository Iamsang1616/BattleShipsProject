using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBehavior : MonoBehaviour {

    public float boostSpeed = 180f;
    public PlayerController pc;

	// Use this for initialization
	void Start () {
        pc = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Fire()
    {
        pc.moveSpeed = boostSpeed;
        GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired = true;
    }
}
