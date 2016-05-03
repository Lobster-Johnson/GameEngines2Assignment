using UnityEngine;
using System.Collections;

public class BoidFlocking : MonoBehaviour
{
    public GameObject Controller;
    public bool inited = false;
    private float minVelocity;
    private float maxVelocity;
    private float randomness;
    public GameObject chasee;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("BoidSteering");
    }

    IEnumerator BoidSteering()
    {
        while (true)
        {
            if (inited)
            {

                this.GetComponent<Boid>().velocity = this.GetComponent<Boid>().velocity + Calc() * Time.deltaTime;

                // enforce minimum and maximum speeds for the boids
                float speed = this.GetComponent<Boid>().velocity.magnitude;
                if (speed > maxVelocity)
                {
                    this.GetComponent<Boid>().velocity = this.GetComponent<Boid>().velocity.normalized * maxVelocity;
                }

                else if (speed < minVelocity)
                {
                    this.GetComponent<Boid>().velocity = this.GetComponent<Boid>().velocity.normalized * minVelocity;
                }
            }

            float waitTime = Random.Range(0.3f, 0.5f);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private Vector3 Calc()
    {
        //change velocity based on the random value, the centre of the flock and the average flock velocity
        Vector3 randomize = new Vector3((Random.value * 2) - 1, (Random.value * 2) - 1, (Random.value * 2) - 1);

        randomize.Normalize();
        FighterFlock boidController = Controller.GetComponent<FighterFlock>();
        Vector3 flockCenter = boidController.flockCenter;
        Vector3 flockVelocity = boidController.flockVelocity;
        Vector3 follow = chasee.transform.localPosition;

        flockCenter = flockCenter - transform.localPosition;
        flockVelocity = flockVelocity - this.GetComponent<Boid>().velocity;
        follow = follow - transform.localPosition;

        return (flockCenter + flockVelocity + follow * 2 + randomize * randomness);
    }

    //set the flock controller of this boid
    public void SetController(GameObject theController)
    {
        Controller = theController;
        FighterFlock boidController = Controller.GetComponent<FighterFlock>();

        minVelocity = boidController.minVelocity;
        maxVelocity = boidController.maxVelocity;
        randomness = boidController.randomness;

        chasee = boidController.chasee;
        inited = true;
    }


}
