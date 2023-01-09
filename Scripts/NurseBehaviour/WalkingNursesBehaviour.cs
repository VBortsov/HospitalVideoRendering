using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Obi;

public class WalkingNursesBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform PathDirectoryForCurrentRoom;
    public float MovementSpeed = 1f;
    public float RotationSpeed = 6f;

    private Transform _NextPoint;
    private Transform _Path;
    private int _PathId;
    private int _PathPointId;
    private int _PathPointEndId;
    private int _PathStep;

    void Start()
    {
        // Checking for the AI position preset
        PathForNurses source = new PathForNurses();
        using (StreamReader r = new StreamReader("./Assets/Scripts/RoomInfo/currentSceneInfo.json"))
        {
            string json = r.ReadToEnd();
            print(JsonConvert.DeserializeObject<PathForNurses>(json));
            source = JsonConvert.DeserializeObject<PathForNurses>(json);
        }
        // if no preset
        if(source == null)
        {
            _PathId = UnityEngine.Random.Range(0, PathDirectoryForCurrentRoom.childCount);
            _Path = PathDirectoryForCurrentRoom.GetChild(_PathId);
            _PathPointId = UnityEngine.Random.Range(0, _Path.transform.childCount);
        }
        else
        {
            _PathId = source.pathId;
            _Path = PathDirectoryForCurrentRoom.GetChild(_PathId);
            _PathPointId = source.pathPointId;        
        }
        using (StreamWriter file = File.CreateText("./Assets/Scripts/RoomInfo/currentSceneInfo.json"))
        {
            JsonSerializer serializer = new JsonSerializer();
            if(source == null)
            {
                source = new PathForNurses();
                source.pathId = _PathId;
                source.pathPointId = _PathPointId;
                serializer.Serialize(file, source);
            }
            else
                serializer.Serialize(file, new PathForNurses());
        }
        print(_Path.transform.childCount + " " + _PathPointId);
        var point = _Path.GetChild(_PathPointId);
        this.transform.position = new Vector3(point.position.x, transform.position.y, point.position.z);
        if(_PathPointId <= (float)_Path.childCount/2)
        {
            _PathStep = 1;
            _PathPointEndId = _Path.childCount;
        }
        else
        {
            _PathStep = -1;
            _PathPointEndId = 0;
        }
        _NextPoint = _Path.GetChild(_PathPointId+_PathStep);
    }

    // Update is called once per frame
    void Update()
    {
        MoveToNextPoint(this.transform.position, new Vector3(_NextPoint.position.x, transform.position.y, _NextPoint.position.z));
        if(new Vector3(this.transform.position.x, 0f, this.transform.position.z) == new Vector3(_NextPoint.position.x, 0f, _NextPoint.position.z)){
            _PathPointId += _PathStep;
            if(_PathPointId != _PathPointEndId-1)
                _NextPoint = _Path.GetChild(_PathPointId + _PathStep);
            else
            {
                if(_PathPointEndId != 0)
                    _PathPointEndId = 0;
                else
                    _PathPointEndId = _Path.childCount;
                _PathStep *= -1;
            }
        }
    }
    
    void MoveToNextPoint(Vector3 pointFrom, Vector3 pointTo){
        var direction = (pointTo - pointFrom).normalized;
        var lookRotation = Quaternion.LookRotation(direction);
        var slerpAmount = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * RotationSpeed);
        this.transform.rotation = slerpAmount;
        print(_NextPoint);
        print(_NextPoint.position);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_NextPoint.position.x, 0f, _NextPoint.position.z), Time.deltaTime * MovementSpeed);
    }
    
    
}
public class PathForNurses
{
    [JsonProperty("pathId")]
    public int pathId{ get; set; }
    [JsonProperty("pathPointId")]
    public int pathPointId{ get; set; }

    public bool isItEmpty(){
        if(pathId == -1)
            return true;
        else
            return false;
    }
}
