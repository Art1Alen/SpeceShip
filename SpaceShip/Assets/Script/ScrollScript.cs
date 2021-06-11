using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public float speed;
    Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

   
    void Update()
    {
        var z = Mathf.Repeat(Time.time * speed, -140);
        var shift = new Vector3(0, 0, -z);
        transform.position = startPosition + shift;
    }
}
