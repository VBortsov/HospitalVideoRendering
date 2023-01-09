using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Obi;


public class CreateColliders : MonoBehaviour
{
    // Start is called before the first frame update
    public ObiCollisionMaterial colMaterial;
    public float Ratio = 1;
    float SpineRadiusRatio;
    float SpineHeightRatio;
    float LegRadiusRatio;
    float LegHeightRatio;
    float HandRadiusRatio;
    float HandHeightRatio;
    float partRadiusRatio = 1f;
    float partHeightRatio = 1f;
    void Start()
    {
        List<Patient> patientTypes = new List<Patient>();
        patientTypes = AddAllColliders();
        createColliders(patientTypes, gameObject.tag);

    }
    void createColliders(List<Patient> patientTypes, string tag){
        if(tag == "MMale"){
            SpineRadiusRatio = patientTypes[0].SpineRadiusRatio;
            SpineHeightRatio = patientTypes[0].SpineHeightRatio;
            LegRadiusRatio = patientTypes[0].LegRadiusRatio;
            LegHeightRatio = patientTypes[0].LegHeightRatio;
            HandRadiusRatio = patientTypes[0].HandRadiusRatio;
            HandHeightRatio = patientTypes[0].HandHeightRatio;
            CreateCollidersForMediumMale(patientTypes[0]);
        }
    }
    void CreateCollidersForMediumMale(Patient patientType){
        foreach (Transform child in transform.GetComponentsInChildren<Transform>())
        {
            ColliderData colData = patientType.Parts.Find(x => x.bodyPart.Contains(child.name));
            if(child.name.Contains("Spine")){
                partRadiusRatio = SpineRadiusRatio;
                partHeightRatio = SpineHeightRatio;
            }
            else if(child.name.Contains("Leg")){
                partRadiusRatio = LegRadiusRatio;
                partHeightRatio = LegHeightRatio;
            }
            else if(child.name.Contains("Shoulder")){
                partRadiusRatio = HandRadiusRatio;
                partHeightRatio = HandHeightRatio;
            }

            if(colData != null){
                CapsuleCollider CapsuleCol = child.gameObject.AddComponent<CapsuleCollider>() as CapsuleCollider;
                CapsuleCol.center = new Vector3(colData.center.x, colData.center.y, colData.center.z);
                CapsuleCol.radius = colData.radius*partRadiusRatio*Ratio;
                CapsuleCol.height = colData.height*partHeightRatio*Ratio;
                ObiCollider obiCol = child.gameObject.AddComponent<ObiCollider>() as ObiCollider;
                obiCol.Thickness = colData.obiThickness;
                obiCol.CollisionMaterial = colMaterial;

            }
        }

    }
    List<Patient> AddAllColliders(){
        List<Patient> source = new List<Patient>();
    
        using (StreamReader r = new StreamReader("./Assets/Scripts/CreateColliders/CapsuleColliders.json"))
        {
            string json = r.ReadToEnd();
            source = JsonConvert.DeserializeObject<List<Patient>>(json);;
        }
        return source;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Patient
{
    [JsonProperty("SpineRadiusRatio")]
    public float SpineRadiusRatio{ get; set; }
    [JsonProperty("SpineHeightRatio")]
    public float SpineHeightRatio{ get; set; }
    [JsonProperty("LegRadiusRatio")]
    public float LegRadiusRatio{ get; set; }
    [JsonProperty("LegHeightRatio")]
    public float LegHeightRatio{ get; set; }
    [JsonProperty("HandRadiusRatio")]
    public float HandRadiusRatio{ get; set; }
    [JsonProperty("HandHeightRatio")]
    public float HandHeightRatio{ get; set; }
    [JsonProperty("Parts")]
    public List<ColliderData> Parts = new List<ColliderData>();
}
public class ColliderData
{
    [JsonProperty("bodyPart")]
    public string bodyPart{ get; set; }
    [JsonProperty("parentBodyPart")]
    public string parentBodyPart{ get; set; }
    [JsonProperty("center")]
    public SerialasableVector3 center{ get; set; }
    [JsonProperty("radius")]
    public float radius{ get; set; }
    [JsonProperty("height")]
    public float height{ get; set; }
    [JsonProperty("obiThickness")]
    public float obiThickness{ get; set; }
}
public class SerialasableVector3
{
    [JsonProperty("x")]
    public float x{ get; set; }
    [JsonProperty("y")]
    public float y{ get; set; }
    [JsonProperty("z")]
    public float z{ get; set; }
}