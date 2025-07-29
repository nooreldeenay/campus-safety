using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public static HealthUI Instance;

    [SerializeField] private Transform heartsContainer;
    [SerializeField] private Transform heartIcon;

    private void Awake()
    {
        Instance = this;
        
        heartIcon.gameObject.SetActive(false);
    }

    public void UpdateHearts()
    {
        foreach (Transform child in heartsContainer)
        {
            if (!child.gameObject.activeSelf) continue;
            Destroy(child.gameObject);
        }
        
        for (int i = 0; i < HealthManager.Instance.GetCurrentHearts(); i++)
        {
            var heart = Instantiate(heartIcon, heartsContainer);
            heart.gameObject.SetActive(true);
        }
    }
}