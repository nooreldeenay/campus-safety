using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    
    [SerializeField] private TextMeshProUGUI timerText;
    
    private float elapsedTime;
    private bool timerActive = true;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!timerActive) return;
        
        elapsedTime += Time.deltaTime;
        
        timerText.text = elapsedTime.ToString("0.00");
    }

    public void StopTimer()
    {
        timerActive = false;
    }
}