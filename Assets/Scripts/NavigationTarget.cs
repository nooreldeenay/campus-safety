using UnityEngine;

public class NavigationTarget : MonoBehaviour
{
    public static NavigationTarget Instance;

    private void Awake()
    {
        Instance = this;
    }
}