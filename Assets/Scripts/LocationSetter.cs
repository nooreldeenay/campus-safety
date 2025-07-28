using System;
using UnityEngine;

public class LocationSetter : MonoBehaviour
{
    [SerializeField] private Transform buildingModel;
    [SerializeField] private NewFireSpawner newFireSpawner;
    
    [SerializeField] private Vector3 c5First;
    [SerializeField] private Vector3 c5Second;
    [SerializeField] private Vector3 c5Third;

    // [SerializeField] private Vector3 c6Ground;
    [SerializeField] private Vector3 c6First;
    [SerializeField] private Vector3 c6Second;
    [SerializeField] private Vector3 c6Third;

    // [SerializeField] private Vector3 c2Ground;
    [SerializeField] private Vector3 c2First;
    [SerializeField] private Vector3 c2Second;
    [SerializeField] private Vector3 c2Third;

    // [SerializeField] private Vector3 c3Ground;
    [SerializeField] private Vector3 c3First;
    [SerializeField] private Vector3 c3Second;
    [SerializeField] private Vector3 c3Third;

    private void Start()
    {
        switch (PlayerData.Instance.selectedFloor)
        {
            case 1:
                buildingModel.position = StartingLocationFromFirstFloorSection();
                break;
            case 2:
                buildingModel.position = StartingLocationFromSecondFloorSection();
                break;
            case 3:
                buildingModel.position = StartingLocationFromThirdFloorSection();
                break;
        }

        if (PlayerData.Instance.selectedSection == Section.C2 || PlayerData.Instance.selectedSection == Section.C3)
        {
            buildingModel.Rotate(Vector3.up, 90f);
        }
        
        newFireSpawner.SpawnFire();
    }

    private Vector3 StartingLocationFromFirstFloorSection()
    {
        switch (PlayerData.Instance.selectedSection)
        {
            case Section.C5:
                return c5First;
                break;
            case Section.C6:
                return c6First;
                break;
            case Section.C2:
                return c2First;
                break;
            case Section.C3:
                return c3First;
                break;
        }
        
        return Vector3.zero;
    }
    
    private Vector3 StartingLocationFromSecondFloorSection()
    {
        switch (PlayerData.Instance.selectedSection)
        {
            case Section.C5:
                return c5Second;
                break;
            case Section.C6:
                return c6Second;
                break;
            case Section.C2:
                return c2Second;
                break;
            case Section.C3:
                return c3Second;
                break;
        }
        
        return Vector3.zero;
    }
    
    private Vector3 StartingLocationFromThirdFloorSection()
    {
        switch (PlayerData.Instance.selectedSection)
        {
            case Section.C5:
                return c5Third;
                break;
            case Section.C6:
                return c6Third;
                break;
            case Section.C2:
                return c2Third;
                break;
            case Section.C3:
                return c3Third;
                break;
        }
        
        return Vector3.zero;
    }
}