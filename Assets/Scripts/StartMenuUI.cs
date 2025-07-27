using System;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI instructionsText;

    [SerializeField] private Transform floorSelectionButtons;
    [SerializeField] private Button groundFloorButton;
    [SerializeField] private Button firstFloorButton;
    [SerializeField] private Button secondFloorButton;
    [SerializeField] private Button thirdFloorButton;

    [SerializeField] private Transform[] floors;

    [SerializeField] private CinemachineCamera topViewCamera;
    [SerializeField] private CinemachineCamera mainViewCamera;

    [SerializeField] private ObjectRotator floorModel;

    private void Awake()
    {
        SwitchToMainView();

        groundFloorButton.onClick.AddListener(() =>
        {
            RemoveFloors(new[] { 1, 2, 3 });
            OnFloorSelected();
        });

        firstFloorButton.onClick.AddListener(() =>
        {
            RemoveFloors(new[] { 0, 2, 3 });
            OnFloorSelected();
        });

        secondFloorButton.onClick.AddListener(() =>
        {
            RemoveFloors(new[] { 0, 1, 3 });
            OnFloorSelected();
        });

        thirdFloorButton.onClick.AddListener(() =>
        {
            RemoveFloors(new[] { 0, 1, 2 });
            OnFloorSelected();
        });
    }

    private void RemoveFloors(int[] removedFloors)
    {
        foreach (var floorIndex in removedFloors)
        {
            floors[floorIndex].gameObject.GetComponent<FloorMenuTransitioner>().Hide();
        }
    }

    private void OnFloorSelected()
    {
        SwitchToTopView();
        
        floorModel.StopRotating();
        floorSelectionButtons.gameObject.SetActive(false);
        
        instructionsText.SetText(
            "Select your starting position"
            );
    }

    private void SwitchToTopView()
    {
        mainViewCamera.Priority = 0;
        topViewCamera.Priority = 1;
    }

    private void SwitchToMainView()
    {
        mainViewCamera.Priority = 1;
        topViewCamera.Priority = 0;
    }
}