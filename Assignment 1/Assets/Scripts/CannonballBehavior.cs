using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballBehavior : MonoBehaviour
{

    public LayerMask collisionMask;

    public float speed;
    public AudioClip bounceSound;
    public AudioSource bounceSource;


    private Vector3 dir;
    private int bouncesToLive;
    private float basePitch;

    // Use this for initialization
    void Start()
    {
        dir = Vector3.forward;
        bouncesToLive = 5;
        speed = 750;
        basePitch = bounceSource.pitch;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.Translate(dir * speed * Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Time.deltaTime * speed + .1f, collisionMask))
        {
            Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
            float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rot, 0);
            bounceSource.Play();
            bounceSource.pitch -= 0.1f;
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            bouncesToLive--;
        }
        //If there are still bounces it can make, adjust the bounce angle of the cannonball and also decrease the pitch of the bounce noise as indication

        if (bouncesToLive <= 0)
        {
            bounceSource.Play();
            Destroy(this.gameObject);
            GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().timeLeft = 0;
            GameObject.FindGameObjectWithTag("Manager").GetComponent<ControlSwitcher>().playerFired = false;
            bounceSource.pitch = basePitch;
        }


    }
}
