using System;
using UnityEngine;

public class FloorMenuTransitioner : MonoBehaviour
{
    [SerializeField] private Vector3 hidingPosition;
    [SerializeField] private float transitionSpeed;
    
    private Vector3 _startingPosition;
    private Vector3 _targetPosition;

    private void Awake()
    {
        _startingPosition = transform.position;
        _targetPosition = _startingPosition;
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
        {
            transform.position = Vector3.Lerp(transform.position, _targetPosition, transitionSpeed * Time.deltaTime);
        }
    }

    public void Hide()
    {
        _targetPosition = hidingPosition;
    }
    
    public void Appear()
    {
        _targetPosition = _startingPosition;
    }
}