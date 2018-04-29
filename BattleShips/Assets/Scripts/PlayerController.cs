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


    public int subWeapon;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody>();
        rotateSpeed = 60f;
        moveSpeed = 90f;
        spreadShot = GetComponent<SpreadShotBehavior>();
        shieldShot = GetComponent<SheildGunBehavior>();
        glueShot = GetComponent<GlueGunBehavior>();
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
            if (Input.GetKey("up"))
            {
                myRigidBody.transform.Translate(-moveAmount, 0, 0);
            }
            if (Input.GetKey("down"))
            {
                myRigidBody.transform.Translate(+moveAmount, 0, 0);
            }
            //stop all movement once a player fires a cannonball
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
				cannonball.dir = Vector3.forward;
                cannonball.bouncesToLive = 5;
                Instantiate(cannonball, LaunchPoint.transform.position,LaunchPoint.transform.rotation);

                this.GetComponent<PlayerController>().enabled = false;
                GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired = true;
				GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().cannonCounter ++;

                fireSource.Play();
			}else if (Input.GetKeyDown(KeyCode.RightControl))
			{

                subWeapon = PlayerPrefs.GetInt("P2_Weapon");

                switch (subWeapon)
                {
                    case 0:
                        shieldShot.Fire();
                        break;

                    case 1:
                        break;

                    case 2:
                        glueShot.Fire();
                        break;

                    case 3:
                        spreadShot.Fire();

                        break;

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
            if (Input.GetKey(KeyCode.W))
            {
                myRigidBody.transform.Translate(-moveAmount, 0, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                myRigidBody.transform.Translate(+moveAmount, 0, 0);
            }
            //Stop all movement once a player fires
            if (Input.GetKeyDown(KeyCode.Q))
			{
				cannonball.dir = Vector3.forward;
                cannonball.bouncesToLive = 5;
                Instantiate(cannonball, LaunchPoint.transform.position, LaunchPoint.transform.rotation);
                
                this.GetComponent<PlayerController>().enabled = false;
                GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired = true;
				GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().cannonCounter ++;
                
                fireSource.Play();

			}
            //Alt weapon slot - for now it's the spread shot
            else if (Input.GetKeyDown(KeyCode.E))
			{

                subWeapon = PlayerPrefs.GetInt("P1_Weapon");

                switch (subWeapon)
                {
                    case 0:
                        shieldShot.Fire();

                        break;

                    case 1:

                        break;

                    case 2:
                        glueShot.Fire();
                        break;

                    case 3:
                        spreadShot.Fire();

                        break;

                }
            }
        }  
    }

}
