
using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInventory
{
    public event Action<ItemSlot, ItemData> OnInventoryChanged;

    public List<ItemSlot> InventoryList { get; private set; } = new List<ItemSlot>();

    public void AddItem(ItemType itemType, ItemData itemData)
    {
        foreach (var slot in InventoryList)
        {
            if (itemType == slot.Type)
            {
                slot.AddToAmount(1);
                OnInventoryChanged?.Invoke(slot, itemData);
                return;
            }
        }

        var newSlot = new ItemSlot(itemType);
        InventoryList.Add(newSlot);
        OnInventoryChanged?.Invoke(newSlot, itemData);
    }
}
