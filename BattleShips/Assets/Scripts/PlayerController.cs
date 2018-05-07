using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float rotateSpeed;
    public GameObject LaunchPoint;
	public CannonballBehavior cannonball;
    public AudioClip fireSound;
    public AudioSource fireSource;

    private Rigidbody myRigidBody;
    private float moveAmount;
    private float rotateAmount;
    private SpreadShotBehavior spreadShot;
    private SheildGunBehavior shieldShot;
    private GlueGunBehavior glueShot;
    private BoostBehavior booster;

    public int subWeapon;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody>();
        rotateSpeed = 60f;
        moveSpeed = 90f;
        spreadShot = GetComponent<SpreadShotBehavior>();
        shieldShot = GetComponent<SheildGunBehavior>();
        glueShot = GetComponent<GlueGunBehavior>();
        booster = GetComponent<BoostBehavior>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        moveAmount = Time.deltaTime * moveSpeed;
        rotateAmount = rotateSpeed * Time.deltaTime;

        //Rotate ships left and right on pressing the buttons
        //Use either WASD or Arrow Keys based on current player
        if (GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().activePlayer == 2)
        {
            

            if (Input.GetKey("left"))
            {
                myRigidBody.transform.Rotate(0, -rotateAmount, 0);
            }
            if (Input.GetKey("right"))
            {
                myRigidBody.transform.Rotate(0, +rotateAmount, 0);
            }
            if (Input.GetKey("up") && GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired == true)
            {
                myRigidBody.transform.Translate(-moveAmount, 0, 0);
            }
            if (Input.GetKey("down") && GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired == true)
            {
                myRigidBody.transform.Translate(+moveAmount, 0, 0);
            }
            //stop all movement once a player fires a cannonball
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                if (GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired == false)
                {
                    cannonball.dir = Vector3.forward;
                    cannonball.bouncesToLive = 4;
                    Instantiate(cannonball, LaunchPoint.transform.position, LaunchPoint.transform.rotation);

                    
                    GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired = true;
                    GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().cannonCounter++;

                    fireSource.Play();
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().timeLeft = 0;
                    this.GetComponent<PlayerController>().enabled = false;
                }
			}
            else if (Input.GetKeyDown(KeyCode.RightControl))
			{
                if (GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired == false)
                {
                    subWeapon = PlayerPrefs.GetInt("P2_Weapon");

                    switch (subWeapon)
                    {
                        case 0:
                            shieldShot.Fire();
                            break;

                        case 1:
                            booster.Fire();
                            break;

                        case 2:
                            glueShot.Fire();
                            break;

                        case 3:
                            spreadShot.Fire();

                            break;

                    }
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().timeLeft = 0;
                    this.GetComponent<PlayerController>().enabled = false;
                }


            }
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                myRigidBody.transform.Rotate(0, -rotateAmount, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                myRigidBody.transform.Rotate(0, +rotateAmount, 0);
            }
            if (Input.GetKey(KeyCode.W) && GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired == true)
            {
                myRigidBody.transform.Translate(-moveAmount, 0, 0);
            }
            if (Input.GetKey(KeyCode.S) && GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired == true)
            {
                myRigidBody.transform.Translate(+moveAmount, 0, 0);
            }
            //Stop all movement once a player fires
            if (Input.GetKeyDown(KeyCode.Q))
			{

                if (GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired == false)
                {
                    cannonball.dir = Vector3.forward;
                    cannonball.bouncesToLive = 4;
                    Instantiate(cannonball, LaunchPoint.transform.position, LaunchPoint.transform.rotation);

                    GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired = true;
                    GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().cannonCounter++;

                    fireSource.Play();
                }

                //end turn if player presses fire key again
                else
                {
                    GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().timeLeft = 0;
                    this.GetComponent<PlayerController>().enabled = false;

                }


            }
            //Alt weapon slot - for now it's the spread shot
            else if (Input.GetKeyDown(KeyCode.E))
			{
                if (GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired == false)
                {
                    subWeapon = PlayerPrefs.GetInt("P1_Weapon");

                    switch (subWeapon)
                    {
                        case 0:
                            shieldShot.Fire();

                            break;

                        case 1:
                            booster.Fire();
                            break;

                        case 2:
                            glueShot.Fire();
                            break;

                        case 3:
                            spreadShot.Fire();

                            break;

                    }
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().timeLeft = 0;
                    this.GetComponent<PlayerController>().enabled = false;
                }
            }
        }  
    }

}
