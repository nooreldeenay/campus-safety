using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public int selectedFloor { get; set; }
    public Section selectedSection { get; set; }

    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }
}

public enum Section
{
    C5,
    C6,
    C2,
    C3
}