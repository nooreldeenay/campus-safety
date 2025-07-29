using Unity.AI.Navigation;
using UnityEngine;

public class NavBuilder : MonoBehaviour
{
    private void Start()
    {
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}
