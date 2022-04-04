
using System;
using Newtonsoft.Json;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public event Action<int> OnMoneyChanged;
    
    // [SerializeField] private int maxHealth;
    // public int MaxHealth => maxHealth;
    // public int Health;
    [JsonProperty("Money")]
    public int Money { get; private set; }

    [SerializeField] private PlayerInventory inventory;
    public PlayerInventory Inventory => inventory;

    public PlayerData()
    {
        // Health = maxHealth;
        inventory = new PlayerInventory();
    }
    
    public void AddMoney(int amount)
    {
        Money += amount;
        OnMoneyChanged?.Invoke(Money);
    }
}
