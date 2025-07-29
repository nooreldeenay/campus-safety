using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameEndUI : MonoBehaviour
{
    [FormerlySerializedAs("mainMenuButton")] [SerializeField] private Button startMenuButton;

    private void Awake()
    {
        startMenuButton.onClick.AddListener(() =>
        {
            SceneLoader.Instance.LoadScene(Scene.StartMenu);
        });
    }
}