using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button resetPlayerDataButton;
    [SerializeField] private Button resetSceneDataButton;

    private void OnEnable()
    {
        resetPlayerDataButton.onClick.AddListener(PlayerDataSaveManager.DeletePlayerData);
        resetSceneDataButton.onClick.AddListener(SceneDataSaveManager.DeleteScenesData);
    }
    
    private void OnDisable()
    {
        resetPlayerDataButton.onClick.RemoveListener(PlayerDataSaveManager.DeletePlayerData);
        resetSceneDataButton.onClick.RemoveListener(SceneDataSaveManager.DeleteScenesData);
    }
}
