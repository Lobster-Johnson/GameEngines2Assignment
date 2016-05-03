using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class FighterFlock : MonoBehaviour
{
    public float minVelocity = 5;
    public float maxVelocity = 10;
    public float randomness = 1;
    public int flockSize = 10;

    public GameObject prefab;
    public GameObject chasee;

    public Vector3 flockCenter;
    public Vector3 flockVelocity;

    private List<GameObject> boids = new List<GameObject>();

    //instantiate the flock
    void Start()
    {
        boids = new List<GameObject>();

        
        for (var i = 0; i < flockSize; i++)
        {
            //set their positions to a random point inside the collider
            Vector3 position = new Vector3
                (
                Random.value * this.GetComponent<Collider>().bounds.size.x,
                Random.value * this.GetComponent<Collider>().bounds.size.y,
                Random.value * this.GetComponent<Collider>().bounds.size.z
            ) - this.GetComponent<Collider>().bounds.extents;

            //instantiate each object at the random position
            GameObject boid = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
            boid.transform.SetParent(transform);
            boid.transform.localPosition = position;

            //set their controller to this
            boid.GetComponent<BoidFlocking>().SetController(gameObject);

            //add them to the list
            boids.Add(boid);
        }
        boids.Add(chasee);
    }

    //every frame, try to calculate the centre of the flock and it's average velocity
    //this is used in each element of the flock
    void Update()
    {
        Vector3 theCenter = Vector3.zero;
        Vector3 theVelocity = Vector3.zero;
        

        foreach (GameObject boid in boids)
        {
            theCenter = theCenter + boid.transform.localPosition;
            theVelocity = theVelocity + boid.GetComponent<Boid>().velocity;
        }

        flockCenter = theCenter / (flockSize);
        flockVelocity = theVelocity / (flockSize);
    }
}
