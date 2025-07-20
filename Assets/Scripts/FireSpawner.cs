using System;
using Unity.AI.Navigation;
using UnityEngine;
using Random = UnityEngine.Random;

public class FireSpawner : MonoBehaviour
{
    [SerializeField] private NavMeshSurface surface;
    [SerializeField] private GameObject[] fires;

    private Scenario _scenario = Scenario.Scenario1;

    private void Start()
    {
        _scenario = (Scenario)Random.Range(0, 2);
        Debug.Log(_scenario);

        switch (_scenario)
        {
            case Scenario.Scenario1:
                fires[0].SetActive(true);
                fires[1].SetActive(false);
                break;
            case Scenario.Scenario2:
                fires[0].SetActive(false);
                fires[1].SetActive(true);
                break;
        }

        surface.BuildNavMesh();
    }
}

enum Scenario
{
    Scenario1,
    Scenario2
}