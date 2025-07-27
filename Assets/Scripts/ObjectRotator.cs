using System;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10;
    
    private void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed);
    }
}
