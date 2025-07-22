using System;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public static FloorManager Instance;

    [SerializeField] private Transform[] stairs;

    private int _currentFloor = 2;

    private void Awake()
    {
        Instance = this;
    }


    public void GoDown()
    {
        _currentFloor--;
    }

    public void GoUp()
    {
        _currentFloor++;
    }

    public void SetCurrentFloor(int floor)
    {
        _currentFloor = floor;
        Debug.Log($"Current floor: {_currentFloor}");
    }

    public Transform GetNextDestination(Vector3 position)
    {
        if (_currentFloor == 0)
            return null;

        Transform stair = FindNearestStair(position);

        return stair;
    }

    private Transform FindNearestStair(Vector3 position)
    {
        Transform nearestStair = stairs[0];

        foreach (var stair in stairs)
        {
            if (Vector3.Distance(stair.position, position) < Vector3.Distance(nearestStair.position, position))
                nearestStair = stair;
        }

        return nearestStair;
    }
}