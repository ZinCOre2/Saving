using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform followTransform;

    [SerializeField] private Vector3 startOffset;
    [SerializeField] private float speed;

    private Vector3 _currentOffset;
    private Vector3 _targetOffset;

    private void Start()
    {
        _currentOffset = transform.position;
        _targetOffset = startOffset;
    }
    private void Update()
    {
        _currentOffset.x = Mathf.Lerp(_currentOffset.x, _targetOffset.x, Mathf.Abs(speed * _targetOffset.normalized.x) * Time.deltaTime);
        _currentOffset.y = Mathf.Lerp(_currentOffset.y, _targetOffset.y, Mathf.Abs(speed * _targetOffset.normalized.y) * Time.deltaTime);
        _currentOffset.z = Mathf.Lerp(_currentOffset.z, _targetOffset.z, Mathf.Abs(speed * _targetOffset.normalized.z) * Time.deltaTime);
    }
    private void LateUpdate()
    {
        transform.position = followTransform.position + _currentOffset;
    }
}
