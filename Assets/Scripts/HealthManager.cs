using System;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;
    
    [SerializeField] private int initialHealth = 2;
    [SerializeField] private Transform building;
    [SerializeField] private Transform lostUI;

    private int currentHealth;

    private void Awake()
    {
        Instance = this;
        
        currentHealth = initialHealth;
    }

    private void Start()
    {
        HealthUI.Instance.UpdateHearts();
    }

    public void TakeDamage()
    {
        currentHealth--;
        if (currentHealth < 0) currentHealth = 0;
        
        HealthUI.Instance.UpdateHearts();

        if (currentHealth == 0)
        {
            building.gameObject.SetActive(false);
            lostUI.gameObject.SetActive(true);
        }
    }

    public int GetCurrentHearts()
    {
        return currentHealth;
    }
}
