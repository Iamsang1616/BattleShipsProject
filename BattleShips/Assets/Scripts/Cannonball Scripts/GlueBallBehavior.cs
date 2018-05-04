using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlueBallBehavior : MonoBehaviour {

    public LayerMask collisionMask;

    public float speed;
    public AudioClip bounceSound;
    public AudioSource bounceSource;
    private Renderer rend;

    public Vector3 dir;
    public int bouncesToLive;
    private float basePitch;


    // Use this for initialization
    void Start () {
        dir = Vector3.forward;
        speed = 750;
        basePitch = bounceSource.pitch;
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(dir * speed * Time.deltaTime);


    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Hit a wall");

            rend = collision.gameObject.GetComponent<Renderer>();


            //Player 1
            if (GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().activePlayer == 1)
            {
                Debug.Log("Making sticky P1");
                collision.gameObject.tag = "StickyOne";
            }

            //Player 2
            else if (GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().activePlayer == 2)
            {
                collision.gameObject.tag = "StickyTwo";
            }

            rend.material.SetColor("_Color", Color.white);


            bounceSource.pitch -= 0.1f;
            bounceSource.Play();
            bouncesToLive--;
        }
        else
            bouncesToLive--;
        //If there are still bounces it can make, adjust the bounce angle of the cannonball and also decrease the pitch of the bounce noise as indication

        if (bouncesToLive <= 0)
        {
            bounceSource.Play();
            Destroy(this.gameObject);

            if (SceneManager.GetActiveScene().name == "TrainingMode")
            {
                GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcherPractice>().cannonCounter++;
            }
            else
            {
                GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().cannonCounter++;
            }
            bounceSource.pitch = basePitch;
        }


    }
}
