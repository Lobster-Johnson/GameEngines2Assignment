using UnityEngine;
using System.Collections;

public class Scene3Trigger : MonoBehaviour
{
    bool mid;
    public GameObject eventmananger;

    //when the fleet goes beyond the halfway point it changes to scene 3
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Cruiser")
        {
            Debug.Log("Cruisers have reached the trigger");
            eventmananger.GetComponent<Events>().OverheadCam();
        }
    }
}
