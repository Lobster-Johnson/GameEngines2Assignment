using UnityEngine;
using System.Collections.Generic;

public class Fighterspawner : MonoBehaviour
{
    public GameObject fighter;
    public GameObject target;
    public int squadSize = 3;
    public Vector3 StartLocation;
    

    // Use this for initialization
    //old fighter instatiation code, no longer used
    void Start ()
    {
        //float x = StartLocation.x;
        //float y = StartLocation.y;
        //float z = StartLocation.z;

        ////spawn in the ships and give them orders
        //for (int i = 0; i < squadSize; i++)
        //{
        //    //spawn ships in a line
        //    GameObject Ship= Instantiate(fighter);
        //    Vector3 start = StartLocation;
        //    Ship.transform.position = start;
            
        //    x = x + 3f;

        //    //give orders
        //    Ship.GetComponent<Boid>();

        //    Vector3 p1 = new Vector3(x +1, 3, -2);
        //    Vector3 p2 = new Vector3(x +1, 0, -1);
        //    Vector3 p3 = new Vector3(x, -3, 0);
        //    Vector3 p4 = new Vector3(x, -3, 4);
        //    Vector3 p5 = new Vector3(x-10, -1, 10);
        //    Vector3 p6 = target.transform.position;
        //    Ship.GetComponent<Boid>().neworders(p1);
        //    Ship.GetComponent<Boid>().neworders(p2);
        //    Ship.GetComponent<Boid>().neworders(p3);
        //    Ship.GetComponent<Boid>().neworders(p4);
        //    Ship.GetComponent<Boid>().neworders(p5);
        //    Ship.GetComponent<Boid>().neworders(p6);
        //}
	}
}
