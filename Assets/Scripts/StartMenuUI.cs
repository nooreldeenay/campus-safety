using System;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI instructionsText;

    [SerializeField] private Transform floorSelectionButtons;

    [SerializeField] private Button startButton;
    [SerializeField] private Button groundFloorButton;
    [SerializeField] private Button firstFloorButton;
    [SerializeField] private Button secondFloorButton;
    [SerializeField] private Button thirdFloorButton;

    [SerializeField] private Transform[] floors;

    [SerializeField] private CinemachineCamera topViewCamera;
    [SerializeField] private CinemachineCamera c5TopViewCamera;
    [SerializeField] private CinemachineCamera c6TopViewCamera;
    [SerializeField] private CinemachineCamera c3TopViewCamera;
    [SerializeField] private CinemachineCamera c2TopViewCamera;
    [SerializeField] private CinemachineCamera mainViewCamera;

    [SerializeField] private ObjectRotator floorModel;

    [SerializeField] private Transform sectionsLabelCanvas;

    [SerializeField] private Button c5SectionButton;
    [SerializeField] private Button c6SectionButton;
    [SerializeField] private Button c2SectionButton;
    [SerializeField] private Button c3SectionButton;

    private bool _groundFloorChosen;

    private int currentPriority = 1;

    private void Awake()
    {
        SwitchToMainView();

        sectionsLabelCanvas.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);

        startButton.onClick.AddListener(() => { SceneLoader.Instance.LoadScene(Scene.MainScene); });

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
            OnSectionSelected();
            // SceneLoader.Instance.LoadScene(Scene.MainScene);
        });

        c6SectionButton.onClick.AddListener(() =>
        {
            PlayerData.Instance.selectedSection = Section.C6;
            OnSectionSelected();
            // SceneLoader.Instance.LoadScene(Scene.MainScene);
        });

        c2SectionButton.onClick.AddListener(() =>
        {
            PlayerData.Instance.selectedSection = Section.C2;
            OnSectionSelected();
            // SceneLoader.Instance.LoadScene(Scene.MainScene);
        });

        c3SectionButton.onClick.AddListener(() =>
        {
            PlayerData.Instance.selectedSection = Section.C3;
            OnSectionSelected();
            // SceneLoader.Instance.LoadScene(Scene.MainScene);
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

    private void OnSectionSelected()
    {
        instructionsText.SetText(
            $"Head to {PlayerData.Instance.selectedSection} and stand on the shown circle and look in the direction of the arrow, then press start"
        );

        switch (PlayerData.Instance.selectedSection)
        {
            case Section.C5:
                SwitchToC5TopView();
                break;
            case Section.C6:
                SwitchToC6TopView();
                break;
            case Section.C2:
                SwitchToC2TopView();
                break;
            case Section.C3:
                SwitchToC3TopView();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        startButton.gameObject.SetActive(true);
    }
    
    private void SwitchToC5TopView()
    {
        c5TopViewCamera.Priority = currentPriority++;
    }
    
    private void SwitchToC2TopView()
    {
        c2TopViewCamera.Priority = currentPriority++;
    }
    
    private void SwitchToC3TopView()
    {
        c3TopViewCamera.Priority = currentPriority++;
    }
    
    private void SwitchToC6TopView()
    {
        c6TopViewCamera.Priority = currentPriority++;
    }
    
    private void SwitchToTopView()
    {
        topViewCamera.Priority = currentPriority++;
    }

    private void SwitchToMainView()
    {
        mainViewCamera.Priority = currentPriority++;
    }
}