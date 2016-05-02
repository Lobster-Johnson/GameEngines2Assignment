using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    public GameObject eventmanager;

    public bool switch1;
    public bool switch2;
    public bool switch3;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //change to the second camera angle
        bool check = eventmanager.GetComponent<Events>().Scene2;
        if (check && !switch1)
        {
            Scene2();
            switch1 = true;
        }

        //change to the second camera angle
        check = eventmanager.GetComponent<Events>().Scene3;
        if (check && !switch2)
        {
            Scene3();
            switch2 = true;
        }
    }

    void Scene2()
    {
        this.transform.position = new Vector3(10, 10, 25);
        this.transform.LookAt(new Vector3(-10, -5, 30));
        
        
    }

    void Scene3()
    {
        this.transform.position = new Vector3(-10, 30, 35);
        this.transform.LookAt(new Vector3(-50, -150, 200));
    }
}
