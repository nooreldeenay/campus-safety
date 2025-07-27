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

    [SerializeField] private Transform sectionsLabelCanvas;

    [SerializeField] private Button c5SectionButton;
    [SerializeField] private Button c6SectionButton;
    [SerializeField] private Button c2SectionButton;
    [SerializeField] private Button c3SectionButton;

    private bool _groundFloorChosen;

    private void Awake()
    {
        SwitchToMainView();

        sectionsLabelCanvas.gameObject.SetActive(false);

        groundFloorButton.onClick.AddListener(() =>
        {
            RemoveFloors(new[] { 1, 2, 3 });

            _groundFloorChosen = true;

            OnFloorSelected();

            PlayerData.Instance.selectedFloor = 0;
        });

        firstFloorButton.onClick.AddListener(() =>
        {
            RemoveFloors(new[] { 0, 2, 3 });
            OnFloorSelected();

            PlayerData.Instance.selectedFloor = 1;
        });

        secondFloorButton.onClick.AddListener(() =>
        {
            RemoveFloors(new[] { 0, 1, 3 });
            OnFloorSelected();

            PlayerData.Instance.selectedFloor = 2;
        });

        thirdFloorButton.onClick.AddListener(() =>
        {
            RemoveFloors(new[] { 0, 1, 2 });
            OnFloorSelected();

            PlayerData.Instance.selectedFloor = 3;
        });

        c5SectionButton.onClick.AddListener(() =>
        {
            PlayerData.Instance.selectedSection = Section.C5;
            SceneLoader.Instance.LoadScene(Scene.MainScene);
        });

        c6SectionButton.onClick.AddListener(() =>
        {
            PlayerData.Instance.selectedSection = Section.C6;
            SceneLoader.Instance.LoadScene(Scene.MainScene);
        });

        c2SectionButton.onClick.AddListener(() =>
        {
            PlayerData.Instance.selectedSection = Section.C2;
            SceneLoader.Instance.LoadScene(Scene.MainScene);
        });

        c3SectionButton.onClick.AddListener(() =>
        {
            PlayerData.Instance.selectedSection = Section.C3;
            SceneLoader.Instance.LoadScene(Scene.MainScene);
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
            "Choose a section to select your starting position"
        );

        sectionsLabelCanvas.gameObject.SetActive(true);

        if (_groundFloorChosen)
        {
            c5SectionButton.gameObject.SetActive(false);
        }
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