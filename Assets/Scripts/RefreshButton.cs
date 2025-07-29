using System;
using UnityEngine;
using UnityEngine.UI;

public class RefreshButton : MonoBehaviour
{
    [SerializeField] private Button button;

    private void Awake()
    {
        button.onClick.AddListener(() =>
        {
            CalibrateUI.Instance.RePickClosestExit();
        });
    }
}