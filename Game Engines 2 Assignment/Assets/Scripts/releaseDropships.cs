using UnityEngine;
using System.Collections.Generic;

public class releaseDropships : MonoBehaviour
{
    public GameObject dropship;
    public int squadSize = 3;
    public GameObject target;

    public GameObject eventmanager;
    public bool dropped = false;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool check = eventmanager.GetComponent<Events>().Scene2;
        if (check && !dropped)
        {
            Drop();
            dropped = true;
        }
    }

    //releases the squad size in dropships
    void Drop()
    {
        Vector3 start = this.transform.position;
        //spawn in the ships and give them orders

        //right side
        for (int i = 0; i < squadSize; i++)
        {
            //spawn dropships
            GameObject Ship = Instantiate(dropship);

            //release the ships
            Ship.transform.position = new Vector3(start.x -1, start.y,  start.z + i);

            //give orders
            Ship.GetComponent<Navigation>();

            Vector3 flyalong = new Vector3(start.x - 5, start.y  - 5, start.z + i);
            //Vector3 descend = new Vector3(x + 1, 0, -1);
            Vector3 dropsite = target.transform.position;

            Ship.GetComponent<Navigation>().neworders(flyalong);
            Ship.GetComponent<Navigation>().neworders(dropsite);
        }

        //left side
        for (int i = 0; i < squadSize; i++)
        {
            //spawn dropships
            GameObject Ship = Instantiate(dropship);

            //release the ships
            Ship.transform.position = new Vector3(start.x + 1, start.y, start.z + i);

            //give orders
            Ship.GetComponent<Navigation>();

            Vector3 flyalong = new Vector3(start.x + 5, start.y - 5, start.z + i);
            //Vector3 descend = new Vector3(x + 1, 0, -1);
            Vector3 dropsite = target.transform.position;

            Ship.GetComponent<Navigation>().neworders(flyalong);
            Ship.GetComponent<Navigation>().neworders(dropsite);
        }
    }
}
