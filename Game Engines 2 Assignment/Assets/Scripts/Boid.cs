using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Boid : MonoBehaviour {
    public Vector3 velocity;
    public Vector3 acceleration;
    public Vector3 force;
    public List<Vector3> waypoints = new List<Vector3>();
    public Vector3 seekTargetPosition;

    public int count = 0;

    public float mass;

    public float maxSpeed = 5.0f;
    public float maxForce = 5.0f;

    public bool seekEnabled;
    public bool followPathEnabled;
    public bool isPartOfFlock;

    // Use this for initialization
    void Start ()
    {
        
	}

    //find target location
    Vector3 Seek(Vector3 target)
    {
        Vector3 toTarget = target - transform.position;
        toTarget.Normalize();
        Vector3 desired = toTarget * maxSpeed;
        return desired - velocity;
    }

    //tell a ship to go to the following location at some point
    public void neworders(Vector3 location)
    {
        followPathEnabled = true; 
        waypoints.Add(location);

    }

    //follow list of waypoints
    Vector3 followPath()
    {
        Vector3 next = waypoints[count];
        if(waypoints != null)
        {
                arriveAtWaypoint(next);
                return Seek(next);
            
        }

        return Vector3.zero;
    }

    //check if you've arrived at location if you're following a path
    void arriveAtWaypoint(Vector3 target)
    {
        Vector3 toTarget = target - transform.position;
        float distance = toTarget.magnitude;

        if (distance < 1f)
        {
            count++;
            if (count >= waypoints.Count)
            {
                count = 0;
            }
            
        }
    }

    //if it's the last waypoint slow down
    //Vector3 FinalWaypoint(Vector3 target)
    //{
    //    Vector3 toTarget = target - transform.position;

    //    float slowingDistance = 15.0f;
    //    float distance = toTarget.magnitude;
    //    if (distance < 1f)
    //    {
    //        velocity = Vector3.zero;
    //        count = 0;
    //        //followPathEnabled = false;
    //        return Vector3.zero;
    //    }
    //    float ramped = maxSpeed * (distance / slowingDistance);

    //    float clamped = Mathf.Min(ramped, maxSpeed);
    //    Vector3 desired = clamped * (toTarget / distance);

    //    return desired - velocity;
    //}

    //code to scatter the ships by sending them to random points
    void Panic()
    {
        followPathEnabled = false;
        //clear out previous orders
        waypoints = new List<Vector3>();
        for(int i = 0; i< 3; i++)
        {

        }
        followPathEnabled = true;
    }

    // Update is called once per frame
    void Update ()
    {
        force = Vector3.zero;

        if (seekEnabled)
        {
            force = Seek(seekTargetPosition);
        }

        if(followPathEnabled)
        {
            force = followPath();
        }

        force = Vector3.ClampMagnitude(force, maxForce);
        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        
        
        
        transform.position += velocity * Time.deltaTime;
        

        if (velocity.magnitude > float.Epsilon)
        {
            transform.forward = velocity;
        }

    }
}
