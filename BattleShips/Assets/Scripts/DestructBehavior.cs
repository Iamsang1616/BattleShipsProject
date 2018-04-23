using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructBehavior : MonoBehaviour {

    public int internalHealth;

    public bool isShield;


	// Use this for initialization
	void Start () {
        if (isShield)
        {
            internalHealth = 1;
        }
        else
        {
            internalHealth = 4;
        }
        
	}


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cannonball")
        {
            internalHealth--;
            this.transform.Translate(0, -20, 0);
        }
    }

    // Update is called once per frame
    void Update () {
		if (internalHealth <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
