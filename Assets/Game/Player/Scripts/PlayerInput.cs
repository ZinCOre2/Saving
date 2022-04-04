using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    public event Action<float> OnHorizontalAxisValue;
    public event Action<float> OnVerticalAxisValue;
    
    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");

        OnHorizontalAxisValue?.Invoke(horizontalInput);
        OnVerticalAxisValue?.Invoke(verticalInput);
    }
}
