using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class turn : MonoBehaviour
{
    public GameObject Camera;
    public Material Celling;
    public Material Walls;
    public Material Walls2_1;
    public Material Walls2_2;
    public Material Floor;
    public Material Tools;
    public Material Wood1;
    public Material Wood2;
    public Material Curtains;
    public List<Texture> HumanClothTextures = new List<Texture>();
    public List<Texture> WallpapersTextures = new List<Texture>();
    public List<Texture> CellingTextures = new List<Texture>();
    public List<Texture> FloorTextures = new List<Texture>();
    public List<Texture> WoodTextures = new List<Texture>();
    public List<Texture> WoodForFurnitureTextures = new List<Texture>();
    public List<Texture> CurtainsTextures = new List<Texture>();
    public List<Texture> DirtTextures = new List<Texture>();
    public List<GameObject> People = new List<GameObject>();
    public List<GameObject> People_AI = new List<GameObject>();
    public Texture nullTexture;
    public Volume m_Volume;
    public Transform TransformFirstRoomForAI;
    public Material BlackColor;
    public Vector3 StartPos;
    public GameObject SceneController;
    public DynamicCameraChange DCC;

    public GameObject barrier1;
    public GameObject barrier2;
    public GameObject barrier3;

    GameObject ActiveSitting;
    GameObject ActiveWalking;
    GameObject ActivePatient;
    GameObject ActiveSitting_AI;
    GameObject ActiveWalking_AI;
    GameObject ActivePatient_AI;

    

    int Room;
    float currentAngle = 90f;

    public static double SampleGaussian(double mean, double stddev)
    {
        // The method requires sampling from a uniform UnityEngine.Random of (0,1]
        // but UnityEngine.Random.NextDouble() returns a sample of [0,1).
        System.Random random = new System.Random();
        double x1 = 1 - random.NextDouble();
        double x2 = 1 - random.NextDouble();

        double y1 = Math.Sqrt(-2.0 * Math.Log(x1)) * Math.Cos(2.0 * Math.PI * x2);
        return y1 * stddev + mean;
    }
    private void SetVariables(Material mat, Color targetColour, Texture targetTexture)
    {
        mat.SetColor("_BaseColor", targetColour);
        mat.SetTexture ("_BaseColorMap", targetTexture);
    }
    private void ChangeEnvironment(int MyGameOBJ)
    {
        Color targetColour;
        int targetTexture;
        if (MyGameOBJ == 1)
        {
            targetTexture = UnityEngine.Random.Range(0, CellingTextures.Count);
            targetColour = new Color(UnityEngine.Random.Range(0.8f, 1f), UnityEngine.Random.Range(0.8f, 1f), UnityEngine.Random.Range(0.8f, 1f));
            SetVariables(Celling, targetColour, CellingTextures[targetTexture]);
        }
        else if (MyGameOBJ == 2)
        {
            targetTexture = UnityEngine.Random.Range(0, WallpapersTextures.Count);
            if (targetTexture == 0 || targetTexture == 3 || targetTexture == 5)
                targetColour = new Color(UnityEngine.Random.Range(0.8f, 1f), UnityEngine.Random.Range(0.8f, 1f), UnityEngine.Random.Range(0.8f, 1f));
            else
                targetColour = new Color(UnityEngine.Random.Range(0.9f, 1f), UnityEngine.Random.Range(0.9f, 1f), UnityEngine.Random.Range(0.9f, 1f));
            SetVariables(Walls, targetColour, WallpapersTextures[targetTexture]);
            SetVariables(Walls2_1, targetColour, WallpapersTextures[targetTexture]);
            SetVariables(Walls2_2, targetColour, WallpapersTextures[targetTexture]);
        }
        else if (MyGameOBJ == 3)
        {
            targetTexture = UnityEngine.Random.Range(0, FloorTextures.Count);
            targetColour = new Color(UnityEngine.Random.Range(0.8f, 1f), UnityEngine.Random.Range(0.8f, 1f), UnityEngine.Random.Range(0.8f, 1f));
            SetVariables(Floor, targetColour, FloorTextures[targetTexture]);
        }
        else if (MyGameOBJ == 4)
        {
            targetColour = new Color(UnityEngine.Random.Range(0.85f, 1f), UnityEngine.Random.Range(0.85f, 1f), UnityEngine.Random.Range(0.85f, 1f));
            SetVariables(Tools, targetColour, nullTexture);
        }
        else if (MyGameOBJ == 5)
        {
            targetTexture = UnityEngine.Random.Range(0, WoodTextures.Count);
            targetColour = new Color(UnityEngine.Random.Range(0.8f, 1f), UnityEngine.Random.Range(0.8f, 1f), UnityEngine.Random.Range(0.8f, 1f));
            SetVariables(Wood1, targetColour, WoodTextures[targetTexture]);
        }
        else if (MyGameOBJ == 6)
        {
            targetTexture = UnityEngine.Random.Range(0, WoodForFurnitureTextures.Count);
            targetColour = new Color(UnityEngine.Random.Range(0.8f, 1f), UnityEngine.Random.Range(0.8f, 1f), UnityEngine.Random.Range(0.8f, 1f));
            SetVariables(Wood2, targetColour, WoodForFurnitureTextures[targetTexture]);
        }
        else if (MyGameOBJ == 7)
        {
            targetTexture = UnityEngine.Random.Range(0, CurtainsTextures.Count);
            targetColour = new Color(UnityEngine.Random.Range(0.8f, 1f), UnityEngine.Random.Range(0.8f, 1f), UnityEngine.Random.Range(0.8f, 1f));
            SetVariables(Curtains, targetColour, CurtainsTextures[targetTexture]);
        }
    }
    IEnumerator ChangeHumans()
    {
        Room = DCC.SetNewCameraPosition();
        ChangePP();
        int SittingChoose = UnityEngine.Random.Range(0, People[(Room-1)*3].transform.childCount);
        int WalkingChoose = UnityEngine.Random.Range(0, People[(Room-1)*3+1].transform.childCount);
        int PatientChoose = UnityEngine.Random.Range(0, People[(Room-1)*3+2].transform.childCount);
        
        Thread.Sleep(100);
        for(int i = 0; i <= 9; i++)
            ChangeEnvironment(i);


        ActiveSitting = People[(Room-1)*3].transform.GetChild(SittingChoose).gameObject;
        ActiveWalking =  People[(Room-1)*3+1].transform.GetChild(WalkingChoose).gameObject;
        ActivePatient =  People[(Room-1)*3+2].transform.GetChild(PatientChoose).gameObject;
        ActiveSitting_AI = People_AI[(Room-1)*3].transform.GetChild(SittingChoose).gameObject;
        ActiveWalking_AI =  People_AI[(Room-1)*3+1].transform.GetChild(WalkingChoose).gameObject;
        ActivePatient_AI =  People_AI[(Room-1)*3+2].transform.GetChild(PatientChoose).gameObject;
        ActiveSitting.SetActive(true);
        ActiveWalking.SetActive(true);
        ActivePatient.SetActive(true);

        int barSpawnRate = UnityEngine.Random.Range(0, 7);
        if(barSpawnRate == 0)
            barrier1.SetActive(true);
        if(barSpawnRate == 1)
            barrier2.SetActive(true);
        if(barSpawnRate == 2)
            barrier3.SetActive(true);
        yield return new WaitForSeconds(2.9f);

        ActiveSitting_AI.SetActive(true);
        ActiveWalking_AI.SetActive(true);
        ActivePatient_AI.SetActive(true);

        Camera.transform.position += new Vector3(10f, 0f, 0f);
        yield return new WaitForSeconds(2.9f);

        SceneManager.LoadScene("Main", LoadSceneMode.Single);

        //StartCoroutine(ChangeHumans());
    }
    /*private void ChangeHumans(int SittingChoose, int WalkingChoose, int PatientChoose)
    {
        Color targetColour;
        if (MyGameOBJ == 1)
        {
            targetColour = new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
            nurse1.transform.Find("Tops").GetComponent<Renderer>().material.SetColor("_Color", targetColour);
            nurse2.transform.Find("Tops").GetComponent<Renderer>().material.SetColor("_Color", targetColour);
            targetColour = new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
            nurse1.transform.Find("Bottoms").GetComponent<Renderer>().material.SetColor("_Color", targetColour);
            nurse2.transform.Find("Bottoms").GetComponent<Renderer>().material.SetColor("_Color", targetColour);
            targetColour = new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
            nurse1.transform.Find("Hats").GetComponent<Renderer>().material.SetColor("_Color", targetColour);
            nurse2.transform.Find("Hats").GetComponent<Renderer>().material.SetColor("_Color", targetColour);

        }
        ActiveSitting = Sitting[SittingChoose];
        ActiveWalking =  Walking[WalkingChoose];
        ActiveSitting.SetActive(true);
        ActiveWalking.SetActive(true);
        ActiveSittingAI = SittingAI[SittingChoose];
        ActiveWalkingAI =  WalkingAI[WalkingChoose];
        ActiveSittingAI.SetActive(true);
        ActiveWalkingAI.SetActive(true);
        ActivePatient1 = Patients[PatientChoose];
        ActivePatient1.SetActive(true);
        ActivePatient1AI = PatientsAI[PatientChoose];
        ActivePatient1AI.SetActive(true);
        ActiveSitting2 = Sitting2[SittingChoose];
        ActiveWalking2 =  Walking2[WalkingChoose];
        ActiveSitting2.SetActive(true);
        ActiveWalking2.SetActive(true);
        ActivePatient2 = Patients2[PatientChoose];
        ActivePatient2.SetActive(true);
        

    }*/
    /*void MakeUlitColor()
    {
        foreach (Transform child in TransformFirstRoomForAI)
            if(child.gameObject.GetComponent<Renderer>() != null)
                //print(child);
                child.gameObject.GetComponent<Renderer>().material = BlackColor;
    }*/
    void StartIterations()
    {
        StartCoroutine(ChangeHumans());
    }
    void Start()
    {
        StartIterations();
    }
    void ChangePP()
    {
        Bloom m_Bloom;
        LiftGammaGain m_LiftGammaGain;
        ColorAdjustments m_ColorAdjustments;
        IndirectLightingController m_ILC;
        Fog m_Fog;
        if(m_Volume.profile.TryGet(out m_Bloom)){
            m_Bloom.intensity.value = (float)SampleGaussian(0.05, 0.4);
            m_Bloom.dirtTexture.value = DirtTextures[UnityEngine.Random.Range(0, DirtTextures.Count)];
        }
        if(m_Volume.profile.TryGet(out m_LiftGammaGain)){
            m_LiftGammaGain.lift.value = new Vector4(0f, 0f, 0f, (float)SampleGaussian(0.0, 0.01));
            m_LiftGammaGain.gamma.value = new Vector4(0f, 0f, 0f, (float)SampleGaussian(0.0, 0.01));
            m_LiftGammaGain.gain.value = new Vector4(0f, 0f, 0f, (float)SampleGaussian(0.0, 0.01));
        }
        if(m_Volume.profile.TryGet(out m_ColorAdjustments)){
            m_ColorAdjustments.postExposure.value = UnityEngine.Random.Range(-2f, 2f);
            m_ColorAdjustments.contrast.value = UnityEngine.Random.Range(-70f, -50f);
            if(UnityEngine.Random.Range(0, 5) == 0)
                m_ColorAdjustments.saturation.value = -100f;
        }
        if(m_Volume.profile.TryGet(out m_ILC)){
            m_ILC.indirectDiffuseLightingMultiplier.value = (float)SampleGaussian(0.0, 2.0);
            m_ILC.reflectionLightingMultiplier.value = (float)SampleGaussian(1.0, 10.0);
        }
    }
    void Update()
    {
        /*if(Math.Abs(Camera.transform.position.x - ActiveSitting.transform.position.x) < 0.03f || Math.Abs(Camera.transform.position.y - ActiveSitting.transform.position.y) < 0.03f || Math.Abs(Camera.transform.position.z - ActiveSitting.transform.position.z) < 0.03f)
            ActiveSitting.SetActive(false);
        else
            ActiveSitting.SetActive(true);
        if(Math.Abs(Camera.transform.position.x - ActiveWalking.transform.position.x) < 0.03f || Math.Abs(Camera.transform.position.y - ActiveWalking.transform.position.y) < 0.03f || Math.Abs(Camera.transform.position.z - ActiveWalking.transform.position.z) < 0.03f)
            ActiveWalking.SetActive(false);
        else
            ActiveWalking.SetActive(true);
        if (transform.position.x < -0.005)
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
            if (transform.position.x >= -0.005 && transform.position.z > -29f)
                transform.Translate(Vector3.forward * Time.deltaTime);
            else
            {
                SceneManager.LoadScene("Main");
                //SetAllInactive();
                //StartIterations();
                //Instantiate(SceneController, StartPos, Quaternion.identity);
                //Destroy(this.gameObject);
            }
        }*/

    }
}
