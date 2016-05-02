using UnityEngine;
using System.Collections.Generic;

public class Fire : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject firelocation;
    public GameObject eventmanager;

    public Vector3 target;
    public Vector3 origin;

    public bool fired = false;
    public bool fired2 = false;

	// Use this for initialization
	void Start ()
    {
        float x = this.transform.position.x;// + 50;
        float y = this.transform.position.y + 50;
        float z = this.transform.position.z - 50;

        origin = new Vector3(x, y, z);
        target = firelocation.transform.position;

        //for (int i = 0;i<10; i++)
        //{
        //    StartFiring();
        //}
    }
	
	// Update is called once per frame
	void Update ()
    {
        bool check = eventmanager.GetComponent<Events>().Scene2;
        if(check && !fired)
        {
            for (int i = 0; i < 10; i++)
            {
                StartFiring();
            }
            fired = true;
        }

        check = eventmanager.GetComponent<Events>().Scene3;
        if(check && !fired2)
        {
            fired = false;
            fired2 = true;
            target.z = target.z + 30;
        }
    }

    //fire out a projectile to fly through space
    void StartFiring()
    {
        //spawn at a random point, select a random target

        Vector3 or = origin + Random.insideUnitSphere * 10;
        Vector3 tar = target + Random.insideUnitSphere * 20;


        GameObject shot = Instantiate(Projectile);
        shot.transform.position = or;
        shot.GetComponent<ProjectileBehaviour>().dest = tar;
    }
}
