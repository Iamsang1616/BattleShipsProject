using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLineBehavior : MonoBehaviour {

    private LineRenderer lr;
    private float reflectDistance;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
        reflectDistance = 2f;
    }

    private void Update()
    {
        lr.SetPosition(0, transform.position);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit)){
            if (hit.collider)
            {

                Vector3 reflectAngle = Vector3.Reflect(ray.direction, hit.normal) * reflectDistance;

                lr.SetPosition(1, hit.point);
                //lr.SetPositions(new[] { transform.position, hit.point, reflectAngle });
            }
        }
        else
        {
            lr.SetPosition(1, transform.forward * 1000);
        }

    }
}   
