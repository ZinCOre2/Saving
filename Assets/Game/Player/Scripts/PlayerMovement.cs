using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    
    public void MovePlayer(float value)
    {
        rb.velocity = transform.forward * movementSpeed * value;
    }
    
    public void RotatePlayer(float value)
    {
        var deltaRotation = Quaternion.Euler(Vector3.up * rotationSpeed * value * Time.deltaTime);
        
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
