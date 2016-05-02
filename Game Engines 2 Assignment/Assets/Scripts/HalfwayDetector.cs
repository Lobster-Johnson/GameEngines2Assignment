using UnityEngine;
using System.Collections;

public class HalfwayDetector : MonoBehaviour
{
    bool mid;
    public GameObject eventmananger;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Cruiser")
        {
            Debug.Log("Cruisers have reached the trigger");
            eventmananger.GetComponent<Events>().MidPoint();
        }
    }
}

