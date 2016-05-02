using UnityEngine;
using System.Collections.Generic;

public class Fighterspawner : MonoBehaviour
{
    public GameObject fighter;
    public GameObject target;
    public int squadSize = 3;
    public int x;
    public int y;
    public int z;
    // Use this for initialization
    void Start ()
    {
        
        //spawn in the ships and give them orders
        for(int i = 0; i < squadSize; i++)
        {
            //spawn ships in a line
            GameObject Ship= Instantiate(fighter);
            Vector3 start = new Vector3(x, y, z);
            Ship.transform.position = start;
            x = x + 3;

            //give orders
            Ship.GetComponent<Navigation>();

            Vector3 p1 = new Vector3(x +1, 3, -2);
            Vector3 p2 = new Vector3(x +1, 0, -1);
            Vector3 p3 = new Vector3(x, -3, 0);
            Vector3 p4 = new Vector3(x, -3, 4);
            Vector3 p5 = target.transform.position;
            Ship.GetComponent<Navigation>().neworders(p1);
            Ship.GetComponent<Navigation>().neworders(p2);
            Ship.GetComponent<Navigation>().neworders(p3);
            Ship.GetComponent<Navigation>().neworders(p4);
            Ship.GetComponent<Navigation>().neworders(p5);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
