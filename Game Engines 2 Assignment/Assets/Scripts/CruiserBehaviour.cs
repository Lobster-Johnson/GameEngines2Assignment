using UnityEngine;
using System.Collections.Generic;

public class CruiserBehaviour : MonoBehaviour
{
    public Vector3 velocity = Vector3.zero;
    public int current = 0;
    public List<Vector3> waypoints = new List<Vector3>();
    bool autonomousFlight = false;

    public float mass = 1.0f;
    public float maxSpeed = 5.0f;

    void start()
    {
        //this.GetComponent<Boid>();
    }



    public void neworders(Vector3 location)
    {
        if (autonomousFlight == false)
        {
            waypoints.Add(location);
        }

    }
    // Update is called once per frame
    void Update()
    {
        //movement code
        if (waypoints.Count != 0)
        {
            if (Vector3.Distance(waypoints[current], transform.position) < 1.0f)
            {
                current = (current + 1) % waypoints.Count;
            }
            Vector3 desired = waypoints[current] - transform.position;
            desired.Normalize();
            desired *= maxSpeed;
            Vector3 force = desired - velocity;

            Vector3 acceleration = force / mass;
            velocity += acceleration * Time.deltaTime;
            transform.Translate(velocity * Time.deltaTime, Space.World);
            transform.forward = velocity;

            //the following code exists to make sure the model works right
        }

    }
}
