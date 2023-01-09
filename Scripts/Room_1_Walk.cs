using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Room_1_Walk : MonoBehaviour
{
    public float rotationSpeed = 100f; 
    public float targetAngle = -178f; 
    float currentAngle = 0f;
    float step = 0f;

    void Update()
    {
        if (transform.localPosition.z < 0.8f && transform.localPosition.x <= 0.98f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
        else if(transform.localPosition.z >= 0.8f)
        {
            //while (true)
            //{
                
                if (currentAngle + step <= targetAngle)
                {
                    step = rotationSpeed * Time.deltaTime;
                    transform.Rotate(Vector3.up, step);
                    currentAngle += step;
                }
                //transform.Rotate(Vector3.up, step);
                //transform.Translate(Vector3.forward * Time.deltaTime);
            //}
            if (transform.localPosition.x <= 1.65f)
                transform.Translate(Vector3.forward * Time.deltaTime);
            else
                transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
