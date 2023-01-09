using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInSH : MonoBehaviour
{

    void Start()
    {
        transform.position = new Vector3(transform.position.x+10f, transform.position.y, transform.position.z);
    }
}
