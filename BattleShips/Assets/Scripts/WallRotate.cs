using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRotate : MonoBehaviour {
	public float speed;// positive for clockwise, negative for counter clockwise, value for rotation speed
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(0, Time.deltaTime * 30*speed, 0);
	}
}
