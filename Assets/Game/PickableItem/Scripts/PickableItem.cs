using System;
using UnityEngine;


public class PickableItem : MonoBehaviour
{
    [SerializeField] private ItemData item;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Player player)) { return; }
        
        player.Data.Inventory.AddItem(item.Type, item);

        gameObject.SetActive(false);
    }
}
