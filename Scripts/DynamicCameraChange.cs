using System.IO;
// Add System.Runtime.Serialization.Formatters.Binary to work with BinaryFormatter!
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DynamicCameraChange : MonoBehaviour
{
    // Start is called before the first frame update
    //public static DynamicCameraChange Instance { get; private set; }
    public GameObject PP;
    public GameObject Cam;
    public Transform target1; 
    public Transform target1_AI;
    public Transform target2; 
    public Transform target2_AI;
    public Transform target3; 
    public Transform target3_AI;
    public Transform target4; 
    public Transform target4_AI;
    public Transform target5; 
    public Transform target5_AI;
    public Transform target6; 
    public Transform target6_AI;
    public int Room;
    public bool isItAIFootage;
    float dif;
    GameObject ActiveWalking;
    // Use this for initialization

    public void Start()
    {
        
    }

    public int SetNewCameraPosition()
    {
        Room = UnityEngine.Random.Range(2, 3);
        //Instance = this;
        ChangeCameraPosition();
        if(isItAIFootage)
            dif = 10f;
        else
            dif = 0f;
        return Room;
    }

    void ChangeCameraPosition(int counter = 0)
    {
        float x, y, z;
        x = y = z = 0;
        //float xDif3 = Math.Abs(transform.position.x - target.transform.position.x);
        //float yDif3 = Math.Abs(transform.position.y - target.transform.position.y);
        //float zDif3 = Math.Abs(transform.position.z - target.transform.position.z);
        if(Room == 1)
        {
            x = UnityEngine.Random.Range(-1.185f, 0.83f)+dif;
            y = UnityEngine.Random.Range(1.167f, 1.74f);
            z = UnityEngine.Random.Range(-29.916f, -27.684f);
            float xDif = Math.Abs(x - target1.transform.position.x);
            float yDif = Math.Abs(y - target1.transform.position.y);
            float zDif = Math.Abs(z - target1.transform.position.z);
            if(xDif < 0.5f || yDif < 0.5f || zDif < 0.5f)
                if(counter < 5)
                {
                    ChangeCameraPosition(counter + 1);
                    return;
                }
                else
                {
                    if(xDif < 0.5f)
                        x += 0.5f - xDif;
                    if(yDif < 0.5f)
                        y += 0.5f - yDif;
                    if(zDif < 0.5f)
                        z += 0.5f - zDif;
                }
        }
        if(Room == 2)
        {
            float xDif = Math.Abs(transform.position.x - target2.transform.position.x);
            float yDif = Math.Abs(transform.position.y - target2.transform.position.y);
            float zDif = Math.Abs(transform.position.z - target2.transform.position.z);
            x = UnityEngine.Random.Range(-0.687f, 1.964f)+dif;
            y = UnityEngine.Random.Range(0.935f, 1.763f);
            z = UnityEngine.Random.Range(0f, 2f);
            if(xDif < 0.5f || yDif < 0.5f || zDif < 0.5f)
                if(counter < 5)
                {
                    ChangeCameraPosition(counter + 1);
                    return;
                }
                else
                {
                    if(xDif < 0.5f)
                        x += 0.5f - xDif;
                    if(yDif < 0.5f)
                        y += 0.5f - yDif;
                    if(zDif < 0.5f)
                        z += 0.5f - zDif;
                }
        }
        if(Room == 3)
        {
            float xDif = Math.Abs(transform.position.x - target3.transform.position.x);
            float yDif = Math.Abs(transform.position.y - target3.transform.position.y);
            float zDif = Math.Abs(transform.position.z - target3.transform.position.z);
            x = UnityEngine.Random.Range(-0.291f, 0.845f)+dif;
            y = UnityEngine.Random.Range(0.8f, 2f);
            z = UnityEngine.Random.Range(8f, 10f);
            if(xDif < 0.5f || yDif < 0.5f || zDif < 0.5f)
                if(counter < 5)
                {
                    ChangeCameraPosition(counter + 1);
                    return;
                }
                else
                {
                    if(xDif < 0.5f)
                        x += 0.5f - xDif;
                    if(yDif < 0.5f)
                        y += 0.5f - yDif;
                    if(zDif < 0.5f)
                        z += 0.5f - zDif;
                }
        }
        if(Room == 4)
        {
            float xDif = Math.Abs(transform.position.x - target4.transform.position.x);
            float yDif = Math.Abs(transform.position.y - target4.transform.position.y);
            float zDif = Math.Abs(transform.position.z - target4.transform.position.z);
            x = UnityEngine.Random.Range(-0.111f, 1.517f)+dif;
            y = UnityEngine.Random.Range(0.172f, 2.1f);
            z = UnityEngine.Random.Range(18.272f, 21.476f);
            if(xDif < 0.5f || yDif < 0.5f || zDif < 0.5f)
                if(counter < 5)
                {
                    ChangeCameraPosition(counter + 1);
                    return;
                }
                else
                {
                    if(xDif < 0.5f)
                        x += 0.5f - xDif;
                    if(yDif < 0.5f)
                        y += 0.5f - yDif;
                    if(zDif < 0.5f)
                        z += 0.5f - zDif;
                }
        }
        if(Room == 5)
        {
            float xDif = Math.Abs(transform.position.x - target5.transform.position.x);
            float yDif = Math.Abs(transform.position.y - target5.transform.position.y);
            float zDif = Math.Abs(transform.position.z - target5.transform.position.z);
            x = UnityEngine.Random.Range(-1.891f, 1.472f)+dif;
            y = UnityEngine.Random.Range(-0.104f, 1.366f);
            z = UnityEngine.Random.Range(28.954f, 32.92f);
            if(xDif < 0.5f || yDif < 0.5f || zDif < 0.5f)
                if(counter < 5)
                {
                    ChangeCameraPosition(counter + 1);
                    return;
                }
                else
                {
                    if(xDif < 0.5f)
                        x += 0.5f - xDif;
                    if(yDif < 0.5f)
                        y += 0.5f - yDif;
                    if(zDif < 0.5f)
                        z += 0.5f - zDif;
                }
        }
        if(Room == 6)
        {
            float xDif = Math.Abs(transform.position.x - target6.transform.position.x);
            float yDif = Math.Abs(transform.position.y - target6.transform.position.y);
            float zDif = Math.Abs(transform.position.z - target6.transform.position.z);
            x = UnityEngine.Random.Range(-1.51f, 0.511f)+dif;
            y = UnityEngine.Random.Range(0.38f, 1.127f);
            z = UnityEngine.Random.Range(37.387f, 42.268f);
            if(xDif < 0.5f || yDif < 0.5f || zDif < 0.5f)
                if(counter < 5)
                {
                    ChangeCameraPosition(counter + 1);
                    return;
                }
                else
                {
                    if(xDif < 0.5f)
                        x += 0.5f - xDif;
                    if(yDif < 0.5f)
                        y += 0.5f - yDif;
                    if(zDif < 0.5f)
                        z += 0.5f - zDif;
                }
        }
        Vector3 position = new Vector3(x, y, z);
        transform.position = position;
        position = new Vector3(x+10f, y, z);
        if(Room == 1)
        {
            if(isItAIFootage)
               transform.LookAt(target1_AI);
            else 
                transform.LookAt(target1);
        }
        if(Room == 2)
        {
            if(isItAIFootage)
               transform.LookAt(target2_AI);
            else 
                transform.LookAt(target2);
        }
        if(Room == 3)
        {
            if(isItAIFootage)
               transform.LookAt(target3_AI);
            else 
                transform.LookAt(target3);
        }
        if(Room == 4)
        {
            if(isItAIFootage)
               transform.LookAt(target4_AI);
            else 
                transform.LookAt(target4);
        }
        if(Room == 5)
        {
            if(isItAIFootage)
               transform.LookAt(target5_AI);
            else 
                transform.LookAt(target5);
        }
        if(Room == 6)
        {
            if(isItAIFootage)
               transform.LookAt(target6_AI);
            else 
                transform.LookAt(target6);
        }
    }
}
