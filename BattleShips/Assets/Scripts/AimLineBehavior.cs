using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLineBehavior : MonoBehaviour {

    private LineRenderer lr;
    private float reflectDistance;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 3;
        reflectDistance = 2f;
    }

    private void Update()
    {
        lr.SetPosition(0, transform.position);

        Ray ray = new Ray(transform.position, transform.forward);
        Ray b;
        RaycastHit hit, hit2;


        if (Physics.Raycast(ray, out hit)){
            if (hit.collider)
            {

                Vector3 reflectAngle = Vector3.Reflect(ray.direction, hit.normal);

                //Make a second ray starting at the hit point and going outward in the normal direction
                b = new Ray (hit.point, reflectAngle);
                Physics.Raycast(b, out hit2);

                //lr.SetPosition(1, hit.point);
                lr.SetPositions(new[] { transform.position, hit.point,  hit2.point});
            }
        }
        else
        {
            lr.SetPosition(1, transform.forward * 1000);
        }

    }
}   
