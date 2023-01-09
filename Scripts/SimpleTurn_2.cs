using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTurn_2 : MonoBehaviour
{
    void Start(){

    }
    void Update()
    {
        Vector3 moveVec = new Vector3(0, 0, 1);
        transform.Translate(moveVec * Time.deltaTime);
    }
}
