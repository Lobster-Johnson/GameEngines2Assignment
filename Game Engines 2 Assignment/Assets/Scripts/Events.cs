using UnityEngine;
using System.Collections;

public class Events : MonoBehaviour
{
    public bool Scene2 = false;
    public bool Scene3 = false;
    public bool Scene4 = false;

	public void MidPoint()
    {
        if(!Scene2)
        {
            Scene2 = true;
        }
    }

    public void OverheadCam()
    {
        if (!Scene3)
        {
            Scene3 = true;
        }
    }
}
