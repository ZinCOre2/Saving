using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    
    [SerializeField] private PlayerInput input;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerData data;
    public PlayerData Data => data;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        
        data = PlayerDataSaveManager.LoadPlayerData();
    }

    private void OnEnable()
    {
        input.OnHorizontalAxisValue += InputOnHorizontalAxisValue;
        input.OnVerticalAxisValue += InputOnVerticalAxisValue;
    }
    private void OnDisable()
    {
        input.OnHorizontalAxisValue -= InputOnHorizontalAxisValue;
        input.OnVerticalAxisValue -= InputOnVerticalAxisValue;
    }
    
    private void InputOnHorizontalAxisValue(float value)
    {
        movement.RotatePlayer(value);
    }
    private void InputOnVerticalAxisValue(float value)
    {
        movement.MovePlayer(value);
    }

    private void OnDestroy()
    {
        PlayerDataSaveManager.SavePlayerData(data);
    }
}
