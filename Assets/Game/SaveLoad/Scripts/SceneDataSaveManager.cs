
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDataSaveManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> sceneGameObjects = new List<GameObject>();

    private static string _scenesDataFolderPath;
    private static string _sceneDataPath;

    private void Start()
    {
        _scenesDataFolderPath = Path.Combine(Application.persistentDataPath, "Saves\\Scenes");
        _sceneDataPath = Path.Combine(_scenesDataFolderPath, $"{SceneManager.GetActiveScene().name}.json");
        
        if (!File.Exists(_sceneDataPath)) { return; }

        var savedObjects = LoadSceneData();

        if (savedObjects == null) { return; }
        
        for (var i = 0; i < sceneGameObjects.Count; i++)
        {
            bool isActive = false;
            foreach (var obj in savedObjects)
            {
                if (obj.Id == i)
                {
                    isActive = obj.IsActive;
                    sceneGameObjects[i].transform.position = new Vector3(obj.Position.X, obj.Position.Y, obj.Position.Z);
                    sceneGameObjects[i].transform.localEulerAngles = new Vector3(obj.Rotation.X, obj.Rotation.Y, obj.Rotation.Z);
                    
                    break;
                }
            }
            
            sceneGameObjects[i].SetActive(isActive);
        }
    }

    public void SaveSceneData()
    {
        if (!Directory.Exists(_scenesDataFolderPath))
        {
            Directory.CreateDirectory(_scenesDataFolderPath);
        }

        var sceneObjectsData = new List<SceneObjectData>();
        for (var i = 0; i < sceneGameObjects.Count; i++) 
        {
            var objectData = new SceneObjectData();
            objectData.GetDataFromGameObject(sceneGameObjects[i], i);
            sceneObjectsData.Add(objectData);
        }
        
        var serializedData = JsonConvert.SerializeObject(sceneObjectsData);
        
        File.WriteAllText(_sceneDataPath, serializedData);
        
        Debug.Log("Scene data saved");
    }

    public List<SceneObjectData> LoadSceneData()
    {
        var sceneObjects = new List<SceneObjectData>();

        if (!File.Exists(_sceneDataPath)) { return sceneObjects; }
        
        var deserializedData = File.ReadAllText(_sceneDataPath);
        Debug.Log(deserializedData);
        sceneObjects = JsonConvert.DeserializeObject<List<SceneObjectData>>(deserializedData);

        Debug.Log($"Scene data loaded");

        return sceneObjects;
    }

    public static void DeleteScenesData()
    {
        if (!Directory.Exists(_scenesDataFolderPath)) { return; }
        
        Directory.Delete(_scenesDataFolderPath, true);
        
        Debug.Log("Scenes data deleted");
    }

    private void OnDisable()
    {
        SaveSceneData();
    }
    private void OnApplicationQuit()
    {
        SaveSceneData();
    }
}
