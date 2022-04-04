
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Game/Item")]
public class ItemData : ScriptableObject
{
    [SerializeField] private ItemType type;
    public ItemType Type => type;
    [SerializeField] private string itemName;
    public string ItemName => itemName;
    [SerializeField] private Sprite itemSprite;
    public Sprite ItemSprite => itemSprite;
}
