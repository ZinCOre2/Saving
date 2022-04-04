using UnityEngine;

public class PickableMoney : MonoBehaviour
{
    [SerializeField] private int amount;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Player player)) { return; }
        
        player.Data.AddMoney(amount);
        
        Debug.Log($"Picked money: {amount}");
        
        gameObject.SetActive(false);
    }
}
