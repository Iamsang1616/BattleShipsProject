using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRandom : MonoBehaviour {
	public float speed;
	float xDir, yDir;
	// Use this for initialization
	void Start () {
		speed = 5;
		xDir = Random.Range (-speed, speed);
		yDir = Random.Range (-speed, speed);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Time.deltaTime * xDir * 30, 0, Time.deltaTime * yDir * 30);
	}

	private void OnCollisionEnter(Collision collision){
		xDir = Random.Range (-speed, speed);
		yDir = Random.Range (-speed, speed);
	}
}
