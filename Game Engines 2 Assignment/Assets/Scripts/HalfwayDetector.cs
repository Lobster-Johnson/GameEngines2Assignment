using UnityEngine;
using System.Collections;

public class HalfwayDetector : MonoBehaviour
{
    bool mid;
    public GameObject eventmananger;

    //this trigger fires when fleet gets halfway to the planet, changing to scene 2
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Cruiser")
        {
            Debug.Log("Cruisers have reached the trigger");
            eventmananger.GetComponent<Events>().MidPoint();
        }
    }
}

