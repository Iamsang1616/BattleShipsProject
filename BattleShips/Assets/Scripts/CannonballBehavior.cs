using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballBehavior : MonoBehaviour
{

    public LayerMask collisionMask;

    public float speed;
    public AudioClip bounceSound;
    public AudioSource bounceSource;


    public Vector3 dir, reflectDir;
    public int bouncesToLive;
    private float basePitch;

    Ray ray;
    RaycastHit hit;


    // Use this for initialization
    void Start()
    {
        dir = Vector3.forward;
        speed = 750;
        basePitch = bounceSource.pitch;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.Translate(dir * speed * Time.deltaTime);
       
        //keep ray from the cannonball's position
        ray = new Ray(transform.position, transform.forward);
       

    }


    private void OnCollisionEnter(Collision collision)
    {
        //only cast the data out to hit on collision against a wall
        Physics.Raycast(ray, out hit);

        if (collision.gameObject.tag == "Wall")
        {
            reflectDir = Vector3.Reflect(ray.direction, hit.normal);
            float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rot, 0);
            bounceSource.pitch -= 0.1f;
            bounceSource.Play();
            bouncesToLive--;
        }
        //If there are still bounces it can make, adjust the bounce angle of the cannonball and also decrease the pitch of the bounce noise as indication

        if (bouncesToLive <= 0)
        {
            bounceSource.Play();
            Destroy(this.gameObject);
            //GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().timeLeft = 0;
            //GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired = false;
			GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().cannonCounter ++;
            bounceSource.pitch = basePitch;
        }


    }
}
