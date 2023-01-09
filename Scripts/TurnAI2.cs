using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class TurnAI2 : MonoBehaviour
{
    void Start()
    {
        Thread.Sleep(100);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime*1.2f);
    }
}