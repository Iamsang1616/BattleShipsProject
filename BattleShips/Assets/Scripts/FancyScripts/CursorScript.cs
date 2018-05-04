using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour {

    public float scale;
    public int moveFrames;

	// Use this for initialization
	void Start () {
        scale = 0.1f;
        moveFrames = 10;
	}
	
	// Update is called once per frame
	void Update () {

        transform.localScale += new Vector3(scale * Time.deltaTime, 0, 0);
        moveFrames--;

        if (moveFrames < 0)
        {
            scale = -scale;
            moveFrames = 10;
        }


	}
}
