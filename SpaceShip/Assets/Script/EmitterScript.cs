using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject asteroid;
    public float minDelay, maxDelay;

    float nextLaunchTime;
    private float launchDelay;

    void Update()
    {
        if (!GameController.isStarted)
        {
            return;
        }
        if(Time.time > nextLaunchTime)
        {
            var shiftX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            var position = transform.position + new Vector3(shiftX, 0, 0);
            Instantiate(asteroid, position, Quaternion.identity);
            nextLaunchTime = Time.time + launchDelay;

        }
    }
}
