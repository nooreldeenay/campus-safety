using System;
using UnityEngine;

public class GameEndManager : MonoBehaviour
{
    [SerializeField] private Transform gameEndUI;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("MainCamera"))
            return;
        
        Timer.Instance.StopTimer();
        
        gameEndUI.gameObject.SetActive(true);
    }
}