using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SimpleTurnAI : MonoBehaviour
{
    public float rotationSpeed = 100f; 
    public float targetAngle = -178f; 
    float currentAngle = 0f;
    float step = 0f;
    GameObject ActiveWalking;
    void Start()
    {
        turn forActive = new turn();
    }
    void Awake()
    {
    }
    void Update()
    {
        if (transform.localPosition.z < 0.8f && transform.localPosition.x <= 10.98f)
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
        else
        {
            //while (true)
            //{
                
                if (currentAngle + step >= -90f)
                {
                    step = rotationSpeed*5 * Time.deltaTime;
                    transform.Rotate(Vector3.up, step);
                    currentAngle += step;
                }
                //transform.Rotate(Vector3.up, step);
                //transform.Translate(Vector3.forward * Time.deltaTime);
            //}
            if (transform.localPosition.x >= 0.5f)
                transform.Translate(Vector3.forward * Time.deltaTime);
            else
            {
                transform.localPosition = new Vector3(0, 0, 0);
                transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                currentAngle = 0f;
            }
        }
    }
}