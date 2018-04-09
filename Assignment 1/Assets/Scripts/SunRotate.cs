using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotate : MonoBehaviour {

    public float rotateSpeed;

	// Use this for initialization
	void Start () {
        rotateSpeed = 10f;
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
	}
}
