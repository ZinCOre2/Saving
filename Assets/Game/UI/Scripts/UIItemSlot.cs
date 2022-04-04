using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemSlot : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text amountText;

    public ItemSlot Slot { get; private set; }
    
    public void SetItemSlotData(ItemSlot itemSlot, ItemData itemData)
    {
        Slot = itemSlot;
        
        image.sprite = itemData.ItemSprite;
        amountText.text = $"{itemSlot.Amount}";
    }
}
