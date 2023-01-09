using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class TurnAI : MonoBehaviour
{
    public float rotationSpeed = 1f; 
    public float targetAngle = 180f; 
    float currentAngle = 90f;
    void Start()
    {
        Thread.Sleep(100);
    }
    void Update()
    {
        if (transform.position.x < 10.0)
            transform.Translate(Vector3.forward * Time.deltaTime);
        else
        {
            //while (true)
            //{
            float step = rotationSpeed * Time.deltaTime;
            if (currentAngle + step >= targetAngle)
            {
                step = targetAngle - currentAngle;
                transform.Rotate(Vector3.up, step);
            }
            currentAngle += step;
            transform.Rotate(Vector3.up, step);
            //}
            if (transform.position.x >= 10.0 && transform.position.z > -29.1)
                transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }
}
