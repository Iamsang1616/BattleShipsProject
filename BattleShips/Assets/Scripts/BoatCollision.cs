using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatCollision : MonoBehaviour {

    public int internalHealth;
    public GameObject Heart1, Heart2, Heart3;
    public AudioSource explodeSource;
    public AudioClip explodeSound;

    public AudioSource hurtSource;
    public ParticleSystem smoke;
    public GameObject explodeFrags;

	// Use this for initialization
	void Start () {
        internalHealth = 3;
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (internalHealth == 2)
        {
            Heart1.SetActive(false);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
        }
        else if (internalHealth == 1)
        {
            Heart1.SetActive(false);
            Heart2.SetActive(false);
            Heart3.SetActive(true);
            smoke.gameObject.SetActive(true);
        }
		if (internalHealth <= 0)
        {
            explodeSource.Play();
            Heart1.SetActive(false);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
            this.gameObject.SetActive(false);

            Instantiate(explodeFrags, this.transform.position, this.transform.rotation);


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if ANY cannonball hits the boat, lose one health and destroy the cannonball
        if (collision.gameObject.tag == "Cannonball")
        {
            internalHealth--;
            if (internalHealth > 0)
            {
                hurtSource.Play();
            }
            
            Destroy(collision.gameObject);
            GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().cannonCounter ++;
            //GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired = false;

        }


    }
}
