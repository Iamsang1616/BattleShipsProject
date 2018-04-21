using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
	public ParticleSystem smoke;
	public GameObject exit;
	// Use this for initialization
	void Start () {
		smoke.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		//if ANY cannonball hits the boat, lose one health and destroy the cannonball
		if (collision.gameObject.tag == "Cannonball") {
			collision.gameObject.transform.position = exit.transform.position;
		}
	}
}
