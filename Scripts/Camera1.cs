using System.IO;
// Add System.Runtime.Serialization.Formatters.Binary to work with BinaryFormatter!
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.IO;

public class Camera1 : MonoBehaviour
{
    public GameObject Pt;
    public bool isItAI = true;
    public Transform TransformFirstRoomForAI;
    float speed = 10f;
    float currentAngle = 0f;
    float targetAngle = 0f;
    string choosePos;
    int chooseRotation;
    Quaternion target;
    float diff = 10;

    public string savePath = "D:/YandexDisk/Project/Assets/save1/1.txt";
    /**
     * Saves the save data to the disk
     */
    public void CreateData(string choose)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(savePath);
        bf.Serialize(file, choose);
        file.Close();
    }

    /**
     * Loads the save data from the disk
     */
    public string ReadData()
    {
        string choose = "31";
        if (File.Exists(savePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(savePath, FileMode.Open);
            choose = (string)bf.Deserialize(file);
            file.Close();
        }
        return ((int.Parse(choose)+1).ToString());
    }

    void Start()
    {
        //chooseRotation = 0;
        //choosePos = "-1";
        choosePos = ReadData();
        CreateData(choosePos);
        if (choosePos == "0")
        {
            transform.position = new Vector3(0.074f+diff, 1.668f, -29.706f);
            target = Quaternion.Euler(140.55f, 157.8f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = 157.8f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "1")
        {
            transform.position = new Vector3(-0.929f+diff, 1.732f, -29.671f);
            target = Quaternion.Euler(140.55f, 182.2f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = 140.55f;
                targetAngle = 182.2f;

            }
        }
        if (choosePos == "2")
        {
            transform.position = new Vector3(0.384f+diff, 1.569f, -29.849f);
            target = Quaternion.Euler(140.55f, 182.2f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = 182.2f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "3")
        {
            transform.position = new Vector3(0.67f+diff, 1.473f, -27.662f);
            target = Quaternion.Euler(140.55f, 44.76f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = 62.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "4")
        {
            transform.position = new Vector3(-1.027f+diff, 1.184f, -27.315f);
            target = Quaternion.Euler(175.9f, -11.6f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "5")
        {
            transform.position = new Vector3(1.306f+diff, 1.19f, -29.02f);
            target = Quaternion.Euler(167.4f, 97.13f, 180f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "6")
        {
            transform.position = new Vector3(-0.419f+diff, 0.96f, -28.169f);
            target = Quaternion.Euler(140.55f, 3.12f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "7")
        {
            transform.position = new Vector3(0.538f+diff, 0.848f, -29.76f);
            target = Quaternion.Euler(178.6f, -218.9f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "8")
        {
            transform.position = new Vector3(-0.358f+diff, 0.879f, -29.842f);
            target = Quaternion.Euler(178.6f, -181f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "9")
        {
            transform.position = new Vector3(-0.462f+diff, 0.898f, -28.067f);
            target = Quaternion.Euler(162.2f, -715.66f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "10")
        {
            transform.position = new Vector3(-0.071f+diff, 0.933f, -28.195f);
            target = Quaternion.Euler(162.2f, -688.4f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "11")
        {
            transform.position = new Vector3(0.042f+diff, 2.073f, -28.762f);
            target = Quaternion.Euler(120.7f, -955.35f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "12")
        {
            transform.position = new Vector3(-0.392f+diff, 1.184f, -28.462f);
            target = Quaternion.Euler(120.7f, -1083f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "13")
        {
            transform.position = new Vector3(-0.396f+diff, 1.176f, -29.38f);
            target = Quaternion.Euler(120.7f, -543.5f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "14")
        {
            transform.position = new Vector3(-0.125f+diff, 1.324f, -29.142f);
            target = Quaternion.Euler(120.7f, -586.5f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "15")
        {
            transform.position = new Vector3(0.102f+diff, 1.398f, -28.29f);
            target = Quaternion.Euler(120.7f, -618.5f, 179.32f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "16") // test
        {
            transform.position = new Vector3(-0.19f, 2.62f, -19.41f+diff);
            target = Quaternion.Euler(120.7f, -842.3f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "17")
        {
            transform.position = new Vector3(-1.391f+diff, 1.984f, -28.713f);
            target = Quaternion.Euler(120.7f, -842.3f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "18")
        {
            transform.position = new Vector3(-0.677f+diff, 1.15f, -28.664f);
            target = Quaternion.Euler(120.7f, -1151.3f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "19")
        {
            transform.position = new Vector3(-1.217f+diff, 2.11f, -28.481f);
            target = Quaternion.Euler(120.7f, -1151.3f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "20")
        {
            transform.position = new Vector3(-1.002f+diff, 2.114f, -27.867f);
            target = Quaternion.Euler(120.7f, -1125.2f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "21")
        {
            transform.position = new Vector3(-3.64f, 3.83f, 8.52f+diff);
            target = Quaternion.Euler(114f, -1177.21f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "22")
        {
            transform.position = new Vector3(-4.883f, 3.273f, 8.379f+diff);
            target = Quaternion.Euler(153f, -1178.41f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "23")
        {
            transform.position = new Vector3(-3.91f, 3.55f, 9.27f+diff);
            target = Quaternion.Euler(153f, -1178.41f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "24")
        {
            transform.position = new Vector3(-5.913f, 3.585f, 8.416f+diff);
            target = Quaternion.Euler(153f, -1178.41f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "25")
        {
            transform.position = new Vector3(-5.46f, 2.73f, 8.19f+diff);
            target = Quaternion.Euler(153f, -1178.41f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "26")
        {
            transform.position = new Vector3(-4.02f, 2.14f, 9.44f+diff);
            target = Quaternion.Euler(198f, -1178.41f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "27")
        {
            transform.position = new Vector3(-3.33f, 2.24f, 9.54f+diff);
            target = Quaternion.Euler(168f, -1178.48f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "28")
        {
            transform.position = new Vector3(-2.15f, 3.33f, 9.71f+diff);
            target = Quaternion.Euler(88f, -1186.1f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "29")
        {
            transform.position = new Vector3(-2.15f, 3.33f, 9.71f+diff);
            target = Quaternion.Euler(88f, -1358f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "30")
        {
            transform.position = new Vector3(-0.33f+diff, 2.62f, -28.79f);
            target = Quaternion.Euler(88f, -1358f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "31")
        {
            transform.position = new Vector3(-0.29f+diff, 1.59f, -28.78f);
            target = Quaternion.Euler(88f, -1358f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "32")
        {
            transform.position = new Vector3(0.7f+diff, 2.54f, -28.6f);
            target = Quaternion.Euler(114f, -1364f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "33")
        {
            transform.position = new Vector3(-0.58f+diff, 2.6f, -28.91f);
            target = Quaternion.Euler(114f, -1364f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "34")
        {
            transform.position = new Vector3(-0.04f+diff, 1.55f, -28.78f);
            target = Quaternion.Euler(114f, -1345.7f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "35")
        {
            transform.position = new Vector3(-2.76f, 2.08f, 31.16f+diff);
            target = Quaternion.Euler(114f, -1345.7f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "36")
        {
            transform.position = new Vector3(-3.616f, 1.661f, 31.172f+diff);
            target = Quaternion.Euler(114f, -1286f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "37")
        {
            transform.position = new Vector3(-2.956f, 1.541f, 31.598f+diff);
            target = Quaternion.Euler(152f, -1327f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "38")
        {
            transform.position = new Vector3(-3.463f, 1.57f, 31.584f+diff);
            target = Quaternion.Euler(152f, -1325.2f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "39")
        {
            transform.position = new Vector3(-2.156f, 1.735f, 31.126f+diff);
            target = Quaternion.Euler(152f, -1325.2f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
        if (choosePos == "40")
        {
            transform.position = new Vector3(-5.012f, 1.604f, 31.161f+diff);
            target = Quaternion.Euler(152f, -1192f, 179.325f);
            transform.rotation = target;
            if (chooseRotation == 1)
            {
                currentAngle = -11.6f;
                targetAngle = 180f;

            }
        }
    }

    //void Update()
    //{
        //float step = speed * Time.deltaTime;
        //if (currentAngle + step >= targetAngle)
        //{
         //   target = Quaternion.Euler(transform.rotation.x, currentAngle, transform.rotation.z);
        //}
       // currentAngle += step;
       // transform.rotation = target;
    //}
}
