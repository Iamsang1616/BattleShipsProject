using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTextScript : MonoBehaviour {

    public float moveSpeed;
    public int moveFrames;

	// Use this for initialization
	void Start () {
        
        moveFrames = 20;
	}
	
	// Update is called once per frame
	void Update () {
        //this.transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        this.transform.localScale += new Vector3(moveSpeed / 10 * Time.deltaTime, moveSpeed/10 * Time.deltaTime, 0);

        moveFrames--;

        if (moveFrames < 0)
        {
            moveFrames = 20;
            moveSpeed = -moveSpeed;
        }
	}
}
