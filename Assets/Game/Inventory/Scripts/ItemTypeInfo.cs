using System;
using UnityEngine;

[System.Serializable]
public class ItemTypeInfo : MonoBehaviour
{
    public static ItemTypeInfo Instance;
    
    [SerializeField] private ItemData[] itemsData;
    public ItemData[] ItemsData => itemsData;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
}
