using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private Text moneyText;
    
    [SerializeField] private Transform inventoryLayoutGroup;
    [SerializeField] private UIItemSlot itemSlotPrefab;

    private List<UIItemSlot> _itemSlots = new List<UIItemSlot>();

    private void Start()
    {
        Player.Instance.Data.Inventory.OnInventoryChanged += Inventory_OnInventoryChanged;
        Player.Instance.Data.OnMoneyChanged += Inventory_OnMoneyChanged;

        foreach (var itemSlot in Player.Instance.Data.Inventory.InventoryList)
        {
            var itemData = ItemTypeInfo.Instance.ItemsData.FirstOrDefault(c => c.Type == itemSlot.Type);

            Inventory_OnInventoryChanged(itemSlot, itemData);
        }
        Inventory_OnMoneyChanged(Player.Instance.Data.Money);
    }
    
    private void OnDisable()
    {
        Player.Instance.Data.Inventory.OnInventoryChanged -= Inventory_OnInventoryChanged;
        Player.Instance.Data.OnMoneyChanged -= Inventory_OnMoneyChanged;
    }

    private void Inventory_OnMoneyChanged(int amount)
    {
        moneyText.text = $"Money: {amount}";
    }

    private void Inventory_OnInventoryChanged(ItemSlot itemSlot, ItemData itemData)
    {
        var uiSlot = _itemSlots.Find(c => c.Slot.Equals(itemSlot));

        if (uiSlot == null)
        {
            var newUISlot = Instantiate(itemSlotPrefab, inventoryLayoutGroup);
            newUISlot.SetItemSlotData(itemSlot, itemData);
            _itemSlots.Add(newUISlot);
            
            return;
        }
        
        uiSlot.SetItemSlotData(itemSlot, itemData);
    }
}
