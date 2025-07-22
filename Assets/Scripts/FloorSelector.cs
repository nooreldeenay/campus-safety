using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloorSelector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentFloorText;
    [SerializeField] private Button selectFloor1Button;
    [SerializeField] private Button selectFloor2Button;
    [SerializeField] private Button selectFloor3Button;

    private void Awake()
    {
        selectFloor1Button.onClick.AddListener(SetFirstFloor);
        selectFloor2Button.onClick.AddListener(SetSecondFloor);
        selectFloor3Button.onClick.AddListener(SetThirdFloor);
    }

    private void UpdateCurrentFloorText(int floor)
    {
        currentFloorText.SetText($"Current floor: {floor}");
    }

    private void SetFirstFloor()
    {
        FloorManager.Instance.SetCurrentFloor(1);
        UpdateCurrentFloorText(1);
    }

    private void SetSecondFloor()
    {
        FloorManager.Instance.SetCurrentFloor(2);
        UpdateCurrentFloorText(2);
    }

    private void SetThirdFloor()
    {
        FloorManager.Instance.SetCurrentFloor(3);
        UpdateCurrentFloorText(3);
    }
}