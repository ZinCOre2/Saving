
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class PlayerDataSaveManager : MonoBehaviour
{
    private static string PLAYER_DATA_PATH = Path.Combine(Application.persistentDataPath, "Saves\\PlayerData.json");
    
    public static void SavePlayerData(PlayerData playerData)
    {
        if (!Directory.Exists(Path.Combine(Application.persistentDataPath, "Saves")))
        {
            Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "Saves"));
        }
        
        var serializedData = JsonConvert.SerializeObject(playerData);
        
        File.WriteAllText(PLAYER_DATA_PATH, serializedData);
        
        Debug.Log("Data saved");
    }

    public static PlayerData LoadPlayerData()
    {
        var playerData = new PlayerData();

        if (!File.Exists(PLAYER_DATA_PATH)) { return playerData; }
        
        var deserializedData = File.ReadAllText(PLAYER_DATA_PATH);
        Debug.Log(deserializedData);
        playerData = JsonConvert.DeserializeObject<PlayerData>(deserializedData);
        
        Debug.Log($"Data loaded");

        return playerData;
    }

    public static void DeletePlayerData()
    {
        if (!File.Exists(PLAYER_DATA_PATH)) { return; }
        
        File.Delete(PLAYER_DATA_PATH);
        
        Debug.Log("Data deleted");
    }
}