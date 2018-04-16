using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float rotateSpeed;
    public GameObject LaunchPoint;
	public CannonballBehavior cannonball, cannonball2;
    public AudioClip fireSound;
    public AudioSource fireSource;

    private Rigidbody myRigidBody;
    private float moveAmount;
    private float rotateAmount;
    


	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody>();
        rotateSpeed = 60f;
        moveSpeed = 90f;
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
                Instantiate(cannonball, LaunchPoint.transform.position,LaunchPoint.transform.rotation);

                this.GetComponent<PlayerController>().enabled = false;
                GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired = true;
				GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().cannonCounter ++;

                fireSource.Play();
			}else if (Input.GetKeyDown(KeyCode.RightControl))
			{
				cannonball.dir = Vector3.forward + new Vector3(0.5f, 0, 0);
				Instantiate(cannonball, LaunchPoint.transform.position+ LaunchPoint.transform.right*20,LaunchPoint.transform.rotation);
				cannonball2.dir = Vector3.forward + new Vector3(-0.5f, 0, 0);
				Instantiate(cannonball2, LaunchPoint.transform.position- LaunchPoint.transform.right*20,LaunchPoint.transform.rotation);

				this.GetComponent<PlayerController>().enabled = false;
				GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired = true;

				fireSource.Play();
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
                Instantiate(cannonball, LaunchPoint.transform.position, LaunchPoint.transform.rotation);
                
                this.GetComponent<PlayerController>().enabled = false;
                GameObject.FindGameObjectWithTag("Manager").GetComponent<   ControlSwitcher>().playerFired = true;
				GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().cannonCounter ++;
                
                fireSource.Play();
			}else if (Input.GetKeyDown(KeyCode.E))
			{
				cannonball.dir = Vector3.forward + new Vector3(0.5f, 0, 0);
				Instantiate(cannonball, LaunchPoint.transform.position+ LaunchPoint.transform.right*20,LaunchPoint.transform.rotation);
				cannonball2.dir = Vector3.forward + new Vector3(-0.5f, 0, 0);
				Instantiate(cannonball2, LaunchPoint.transform.position- LaunchPoint.transform.right*20,LaunchPoint.transform.rotation);

				this.GetComponent<PlayerController>().enabled = false;
				GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired = true;

				fireSource.Play();
			}
        }  
    }

}
