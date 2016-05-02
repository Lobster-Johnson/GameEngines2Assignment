using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class Navigation : MonoBehaviour
{
    public Vector3 velocity = Vector3.zero;
    public int current = 0;
    public List<Vector3> waypoints = new List<Vector3>();
    bool autonomousFlight = false;
    public GameObject target = null;
    
    public float mass = 1.0f;
    public float maxSpeed = 5.0f;

    void start()
    {
        //this.GetComponent<Boid>();
        
        neworders(target.transform.position);
        
    }

    

    public void neworders(Vector3 location)
    {
        if(autonomousFlight == false)
        {
            waypoints.Add(location);
        }
        
    }
	// Update is called once per frame
	void Update ()
    {
        //movement code
        if(waypoints.Count != 0)
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
            transform.forward = velocity + ObstacleAvoidance();
        }
        
    }

    //obstacle avoidance disabled
    Vector3 ObstacleAvoidance()
    {
        Vector3 force = Vector3.zero;
        //List<GameObject> tagged = new List<GameObject>();
        //float minBoxLength = 50.0f;
        //float boxLength = minBoxLength + ((velocity.magnitude / maxSpeed) * minBoxLength * 2.0f);

        //GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Fireball");

        //// Matt Bucklands Obstacle avoidance
        //// First tag obstacles in range
        //if (obstacles.Length == 0)
        //{
        //    return Vector3.zero;
        //}

        ////check all game objects to see if any are too close
        //foreach (GameObject obstacle in obstacles)
        //{
        //    if (obstacle == null)
        //    {
        //        Debug.Log("Null object");
        //        continue;
        //    }

        //    Vector3 toCentre = transform.position - obstacle.transform.position;
        //    float dist = toCentre.magnitude;
        //    if (dist < boxLength)
        //    {
        //        tagged.Add(obstacle);
        //    }


        //}

        //float distToClosestIP = float.MaxValue;
        //GameObject closestIntersectingObstacle = null;
        //Vector3 localPosOfClosestObstacle = Vector3.zero;
        //Vector3 intersection = Vector3.zero;

        ////check all objects that are too close
        //foreach (GameObject o in tagged)
        //{
        //    Vector3 localPos = transform.InverseTransformPoint(o.transform.position);

        //    // If the local position has a positive Z value then it must lay
        //    // behind the agent. (in which case it can be ignored)
        //    if (localPos.z >= 0)
        //    {
        //        // If the distance from the x axis to the object's position is less
        //        // than its radius + half the width of the detection box then there
        //        // is a potential intersection.

        //        float obstacleRadius = o.transform.localScale.x / 2;
        //        float expandedRadius = GetRadius() + obstacleRadius;
        //        if ((Math.Abs(localPos.y) < expandedRadius) && (Math.Abs(localPos.x) < expandedRadius))
        //        {
        //            // Now to do a ray/sphere intersection test. The center of the				
        //            // Create a temp Entity to hold the sphere in local space
        //            Sphere tempSphere = new Sphere(expandedRadius, localPos);

        //            // Create a ray
        //            Ray ray = new Ray();
        //            ray.pos = new Vector3(0, 0, 0);
        //            ray.look = Vector3.forward;

        //            // Find the point of intersection
        //            if (tempSphere.closestRayIntersects(ray, Vector3.zero, ref intersection) == false)
        //            {
        //                continue;
        //            }

        //            // Now see if its the closest, there may be other intersecting spheres
        //            float dist = intersection.magnitude;
        //            if (dist < distToClosestIP)
        //            {
        //                dist = distToClosestIP;
        //                closestIntersectingObstacle = o;
        //                localPosOfClosestObstacle = localPos;
        //            }
        //        }
        //    }
        //}
        //if (closestIntersectingObstacle != null)
        //{
        //    Debug.Log("Object too close");

        //    // Now calculate the force
        //    float multiplier = 1.0f + (minBoxLength - localPosOfClosestObstacle.z) / boxLength;

        //    //calculate the lateral force
        //    float obstacleRadius = closestIntersectingObstacle.transform.localScale.x / 2;
        //    float expandedRadius = GetRadius() + obstacleRadius;
        //    force.x = (expandedRadius - Math.Abs(localPosOfClosestObstacle.x)) * multiplier;
        //    force.y = (expandedRadius - Math.Abs(localPosOfClosestObstacle.y)) * multiplier;

        //    // Generate positive or negative direction so we steer around!
        //    // Not always in the same direction as in Matt Bucklands book
        //    if (localPosOfClosestObstacle.x > 0)
        //    {
        //        force.x = -force.x;
        //    }

        //    // If the obstacle is above, steer down
        //    if (localPosOfClosestObstacle.y > 0)
        //    {
        //        force.y = -force.y;
        //    }
        //    //apply a braking force proportional to the obstacle's distance from
        //    //the vehicle.
        //    const float brakingWeight = 0.01f;
        //    force.z = (expandedRadius -
        //                       localPosOfClosestObstacle.z) *
        //                       brakingWeight;

        //    //finally, convert the steering vector from local to world space
        //    // Dont include position!                    
        //    force = transform.TransformDirection(force);
        //}

        return force;
    }

    private float GetRadius()
    {
        Renderer r = GetComponent<Renderer>();
        if (r == null)
        {
            return 5.0f;
        }
        else
        {
            return r.bounds.extents.magnitude;
        }
    }


}

//public class Ray
//{
//    public Vector3 pos;
//    public Vector3 look;
//}

//public class Sphere
//{
//    public float radius;
//    public Vector3 Position;

//    public Sphere(float radius, Vector3 position)
//    {
//        this.radius = radius;
//        this.Position = position;
//    }
//    public bool closestRayIntersects(Ray ray, Vector3 point, ref Vector3 intersection)
//    {
//        // Calculate p0-c call it v

//        Vector3 v = ray.pos - Position;
//        Vector3 p0 = Vector3.zero, p1 = Vector3.zero;

//        // Now calculate a, b and c
//        float a, b, c;
        
//        a = Vector3.Dot(ray.look, ray.look);
//        b = 2.0f * Vector3.Dot(v, ray.look);
//        c = Vector3.Dot(v, v) - (radius * radius);

//        // Calculate the discriminant
//        float discriminant = (b * b) - (4.0f * a * c);

//        // Test for imaginary number
//        // If discriminant > 0, calculate values for t0 and t1
//        // Substitute into the ray equation and calculate the 2 intersection points
//        // Push the interesctions into the vector intersections
//        if (discriminant >= 0.0f)
//        {

//            discriminant = (float)Math.Sqrt(discriminant);

//            float t0 = (-b + discriminant) / (2.0f * a);
//            float t1 = (-b - discriminant) / (2.0f * a);

//            p0 = ray.pos + (ray.look * t0);
//            p1 = ray.pos + (ray.look * t1);

//            if ((point - p0).magnitude < (point - p1).magnitude)
//            {
//                intersection = p0;
//            }
//            else
//            {
//                intersection = p1;
//            }
//            return true;
//        }
//        return false;
//    }
//}
