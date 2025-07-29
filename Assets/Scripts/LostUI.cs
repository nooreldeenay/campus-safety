using System;
using UnityEngine;
using UnityEngine.UI;

public class LostUI : MonoBehaviour
{
    [SerializeField] private Button restartButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(() =>
        {
            SceneLoader.Instance.LoadScene(Scene.StartMenu);
        });
    }
}