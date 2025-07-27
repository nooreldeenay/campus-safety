using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI instructionsText;

    [SerializeField] private Button groundFloorButton;
    [SerializeField] private Button firstFloorButton;
    [SerializeField] private Button secondFloorButton;
    [SerializeField] private Button thirdFloorButton;

    [SerializeField] private Transform[] floors;

    private void Awake()
    {
        groundFloorButton.onClick.AddListener(() =>
        {
            RemoveFloors(new []{1, 2, 3});
        });
        
        firstFloorButton.onClick.AddListener(() =>
        {
            RemoveFloors(new []{0, 2, 3});
        });
        
        secondFloorButton.onClick.AddListener(() =>
        {
            RemoveFloors(new []{0, 1, 3});
        });
        
        thirdFloorButton.onClick.AddListener(() =>
        {
            RemoveFloors(new []{0, 1, 2});
        });
    }

    private void RemoveFloors(int[] removedFloors)
    {
        foreach (var floorIndex in removedFloors)
        {
            floors[floorIndex].gameObject.GetComponent<FloorMenuTransitioner>().Hide();
        }
    }
}