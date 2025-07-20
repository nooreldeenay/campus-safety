using System;
using Unity.AI.Navigation;
using UnityEngine;
using Random = UnityEngine.Random;

public class NewFireSpawner : MonoBehaviour
{
    [SerializeField] private GameObject firePrefab;
    [SerializeField] private Collider fireArea1;
    [SerializeField] private NavMeshSurface surface;

    private void Start()
    {
        float extentZ = fireArea1.bounds.extents.z;
        float extentX = fireArea1.bounds.extents.x;
        
        for (int i = 0; i < 3; i++)
        {
            Vector3 pos = fireArea1.bounds.center + new Vector3(
                Random.Range(-extentX, extentX),
                1,
                Random.Range(-extentZ, extentZ)
            );

            Instantiate(firePrefab, pos, Quaternion.identity);
        }

        surface.BuildNavMesh();
    }
}