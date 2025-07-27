using System;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10;
    
    private bool _isRotating;

    private void Awake()
    {
        ContinueRotating();
    }

    private void Update()
    {
        if (!_isRotating) return;
        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed);
    }

    public void ContinueRotating()
    {
        _isRotating = true;
    }
    
    public void StopRotating()
    {
        _isRotating = false;
        transform.rotation = Quaternion.identity;
    }
}
