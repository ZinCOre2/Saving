using Newtonsoft.Json;
using UnityEngine;

[System.Serializable]
public class SceneObjectData
{
    [JsonProperty("Id")]
    public int Id { get; private set; }
    [JsonProperty("IsActive")]
    public bool IsActive { get; private set; }
    [JsonProperty("Name")]
    public string Name { get; private set; }
    [JsonProperty("Position")]
    public Vec3 Position { get; private set; }
    [JsonProperty("Rotation")]
    public Vec3 Rotation { get; private set; }

    public void GetDataFromGameObject(GameObject gameObject, int id)
    {
        Id = id;
        IsActive = gameObject.activeSelf;
        Name = gameObject.name;
        Position = new Vec3(gameObject.transform.position);
        Rotation = new Vec3(gameObject.transform.localEulerAngles);
    }
    
    // public GameObject ConvertToSceneObject()
    // {
    //     var gameObject = new GameObject(Name)
    //     {
    //         transform =
    //         {
    //             position = new Vector3(Position.X, Position.Y, Position.Z),
    //             localEulerAngles = new Vector3(Rotation.X, Rotation.Y, Rotation.Z)
    //         }
    //     };
    //
    //     return gameObject;
    // }
}

[System.Serializable]
public struct Vec3
{
    [JsonProperty("X")]
    public float X;
    [JsonProperty("Y")]
    public float Y;
    [JsonProperty("Z")]
    public float Z;

    public Vec3(Vector3 vector)
    {
        X = vector.x;
        Y = vector.y;
        Z = vector.z;
    }
}
