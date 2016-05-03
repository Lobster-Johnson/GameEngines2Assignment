using UnityEngine;
using System.Collections.Generic;

public class ProjectileBehaviour : MonoBehaviour
{
    public Vector3 dest;
    public float maxSpeed = 7.5f;
    public Vector3 velocity = Vector3.zero;
    public float mass = 0.5f;
    public GameObject Explosion;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// projectile keeps flying at it's destination
    //if it passes it it dies
	void Update ()
    {
	    if(this.transform.position.y >= dest.y)
        {
            Destroy(this.gameObject);
        }

        Vector3 desired = dest - transform.position;
        desired.Normalize();
        desired *= maxSpeed;
        Vector3 force = desired - velocity;

        Vector3 acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;
        transform.Translate(velocity * Time.deltaTime, Space.World);
        transform.forward = velocity;
    }

    //if a projectile hits a ship
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Cruiser")
        {
            //explode
            Vector3 location = (this.transform.position);
            GameObject blast = Instantiate(Explosion);
            blast.transform.position = location;

            HitChange();
            Destroy(this.gameObject);
        }
    }

    //change scene when a ship gets hit
    void HitChange()
    {
        GameObject[] events = GameObject.FindGameObjectsWithTag("Event");
        events[0].GetComponent<Events>().Hit();
    }
}
