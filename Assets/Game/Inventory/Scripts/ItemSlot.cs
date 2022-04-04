
using UnityEngine;

[System.Serializable]
public class ItemSlot
{
    public ItemType Type { get; private set; }
    public int Amount { get; private set; }

    public ItemSlot(ItemType type, int amount = 1)
    {
        Type = type;
        Amount = amount;
    }
    
    public void AddToAmount(int value)
    {
        Amount += value;
    }
}
