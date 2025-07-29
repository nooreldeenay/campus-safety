using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fire : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("MainCamera"))
            return;
        
        HealthManager.Instance.TakeDamage();
    }

    private void Awake()
    {
        if (Random.Range(0f, 1f) > 0.5f)
        {
            gameObject.SetActive(false);
        }
    }
}