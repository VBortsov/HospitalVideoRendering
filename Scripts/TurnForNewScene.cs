using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class TurnForNewScene : MonoBehaviour
{
    public GameObject nurse1;
    public GameObject nurse2;
    public GameObject Patient;
    private void ChangeColor(int MyGameOBJ)
    {
        Color targetColour;
        if (MyGameOBJ == 1)
        {
            targetColour = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
            nurse1.transform.Find("Tops").GetComponent<Renderer>().material.SetColor("_Color", targetColour);
            nurse2.transform.Find("Tops").GetComponent<Renderer>().material.SetColor("_Color", targetColour);
            targetColour = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
            nurse1.transform.Find("Bottoms").GetComponent<Renderer>().material.SetColor("_Color", targetColour);
            nurse2.transform.Find("Bottoms").GetComponent<Renderer>().material.SetColor("_Color", targetColour);
            targetColour = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
            nurse1.transform.Find("Hats").GetComponent<Renderer>().material.SetColor("_Color", targetColour);
            nurse2.transform.Find("Hats").GetComponent<Renderer>().material.SetColor("_Color", targetColour);

        }
        else if (MyGameOBJ == 2)
        {
            targetColour = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            Patient.transform.Find("Tops").Find("Tops").GetComponent<Renderer>().material.SetColor("_Color", targetColour);
            targetColour = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
            Patient.transform.Find("Hair").Find("Hair").GetComponent<Renderer>().material.SetColor("_Color", targetColour);
        }
    }
    void Start()
    {
        Thread.Sleep(100);
        ChangeColor(1);
        ChangeColor(2);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime*1.2f);
    }
}