using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    bool first = false;
    bool second = false;
    bool third = false;
    bool forth = false;
    bool fifth = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 1.53f, -2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z <= 1.88f)
            transform.Translate(new Vector3(0, 0.5f, 1)  * Time.deltaTime*1.2f);
        else{
            if(!first)
                transform.position = new Vector3(0f, 1.53f, 8f);
            first = true;
            if(transform.position.z <= 11f)
                transform.Translate(new Vector3(0, 0.5f, 1f) * Time.deltaTime*1.2f);
            else{
                if(!second)
                    transform.position = new Vector3(1f, 1.53f, 18f);
                second = true;
                if(transform.position.z <= 21f)
                    transform.Translate(new Vector3(0, 0.5f, 1f) * Time.deltaTime*1.2f);
                else{
                    if(!third)
                        transform.position = new Vector3(0f, 1f, 27f);
                    third = true;
                    if(transform.position.z <= 32f)
                        transform.Translate(new Vector3(0, 0.5f, 1f) * Time.deltaTime*1.2f);
                    else{
                        if(!forth)
                        {
                            transform.position = new Vector3(0f, 1f, 44f);
                            transform.Rotate(60f, 180f, 0f);
                        }
                        forth = true;
                        if(transform.position.z >= 38f)
                            transform.Translate(new Vector3(0, 0.5f, 1f) * Time.deltaTime*1.2f);
                    }
                }
            }
        }
            
    }
}
