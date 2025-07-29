using System;
using System.Collections.Generic;
using System.Linq;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CalibrateUI : MonoBehaviour
{
    public static CalibrateUI Instance;
    
    [SerializeField] private Transform player;
    [SerializeField] private Transform target;
    [SerializeField] private NavMeshSurface navMeshSurface;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float pathYOffset = 1;
    [SerializeField] private Transform[] exits;

    private NavMeshPath navMeshPath;

    private void Awake()
    {
        Instance = this;
        
        navMeshPath = new NavMeshPath();

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Update()
    {
        // if (_navigationTargets.Count > 0)
        if (target)
        {
            // _navMeshSurface.BuildNavMesh();
            NavMesh.CalculatePath(player.position + Vector3.down * 0.7f, target.position, NavMesh.AllAreas,
                navMeshPath);

            if (navMeshPath.status == NavMeshPathStatus.PathComplete)
            {
                Vector3[] waypoints = navMeshPath.corners;

                for (int i = 0; i < waypoints.Length; i++)
                {
                    waypoints[i].y += pathYOffset;
                }


                lineRenderer.positionCount = navMeshPath.corners.Length;
                lineRenderer.SetPositions(waypoints);
            }
            else
            {
                lineRenderer.positionCount = 0;
            }
        }
    }

    public void RePickClosestExit()
    {
        Transform nearest = exits[0];

        foreach (var exit in exits)
        {
            if (Vector3.SqrMagnitude(player.position - exit.position) <
                Vector3.SqrMagnitude(player.position - nearest.position))
            {
                nearest = exit;
            }
        }

        target.position = nearest.position;
    }
}