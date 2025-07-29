using System;
using UnityEngine;

public class NewLocationSetter : MonoBehaviour
{
    public static NewLocationSetter Instance;

    [SerializeField] private Transform xrOrigin;

    [SerializeField] private float groundFloorYLevel;
    [SerializeField] private float firstFloorYLevel;
    [SerializeField] private float secondFloorYLevel;
    [SerializeField] private float thirdFloorYLevel;

    [SerializeField] private Transform c5Location;
    [SerializeField] private Transform c6Location;
    [SerializeField] private Transform c3Location;
    [SerializeField] private Transform c2Location;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        switch (PlayerData.Instance.selectedSection)
        {
            case Section.C5:
                xrOrigin.position = c5Location.position;
                xrOrigin.rotation = c5Location.rotation;
                break;
            case Section.C6:
                xrOrigin.position = c6Location.position;
                xrOrigin.rotation = c5Location.rotation;
                break;
            case Section.C2:
                xrOrigin.position = c2Location.position;
                xrOrigin.rotation = c5Location.rotation;
                break;
            case Section.C3:
                xrOrigin.position = c3Location.position;
                xrOrigin.rotation = c5Location.rotation;
                break;
        }

        switch (PlayerData.Instance.selectedFloor)
        {
            case 1:
                xrOrigin.position = new Vector3(xrOrigin.position.x, firstFloorYLevel, xrOrigin.position.z);
                break;
            case 2:
                xrOrigin.position = new Vector3(xrOrigin.position.x, secondFloorYLevel, xrOrigin.position.z);
                break;
            case 3:
                xrOrigin.position = new Vector3(xrOrigin.position.x, thirdFloorYLevel, xrOrigin.position.z);
                break;
        }
    }
}