using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMovement : MonoBehaviour {

    public float rotateSpeed;


	// Use this for initialization
	void Start () {
        rotateSpeed = 14;
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
	}
}
