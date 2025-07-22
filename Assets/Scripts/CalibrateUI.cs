using System;
using System.Collections.Generic;
using System.Linq;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CalibrateUI : MonoBehaviour
{
    [SerializeField] private GameObject trackedImagePrefab;
    [SerializeField] private Transform player;
    [SerializeField] private Transform xrSessionOrigin;
    [SerializeField] private Transform calibrateTransform;
    [SerializeField] private NavMeshSurface navMeshSurface;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float pathYOffset = 1;
    [SerializeField] Button calibrateButton;
    [SerializeField] private GuidanceLine.GuidanceLine guidanceLine;

    // private List<NavigationTarget> _navigationTargets = new();
    private Transform _target;
    private GameObject _navigationBase;

    private NavMeshPath _navMeshPath;

    private void Awake()
    {
        calibrateButton.onClick.AddListener(OnCalibrateClicked);

        _navMeshPath = new NavMeshPath();

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Update()
    {
        // if (_navigationTargets.Count > 0)
        if (_target != null)
        {
            Debug.Log(_target.position);
            // _navMeshSurface.BuildNavMesh();
            NavMesh.CalculatePath(player.position, _target.position, NavMesh.AllAreas,
                _navMeshPath);

            if (_navMeshPath.status == NavMeshPathStatus.PathComplete)
            {
                Vector3[] waypoints = _navMeshPath.corners;

                for (int i = 0; i < waypoints.Length; i++)
                {
                    waypoints[i].y += pathYOffset;
                }


                lineRenderer.positionCount = _navMeshPath.corners.Length;
                lineRenderer.SetPositions(waypoints);
            }
            else
            {
                lineRenderer.positionCount = 0;
            }
        }
    }

    private void OnCalibrateClicked()
    {
        // xrSessionOrigin.SetPositionAndRotation(
        //     calibrateTransform.position,
        //     Quaternion.Euler(0, calibrateTransform.rotation.eulerAngles.y, 0));

        // navigationBase.SetActive(true);

        // _navigationTargets.Clear();
        // _navigationTargets = new List<NavigationTarget>() { NavigationTarget.Instance };

        _target = FloorManager.Instance.GetNextDestination(player.position);
        Debug.Log(_target);
        // navMeshSurface = _navigationBase.GetComponentInChildren<NavMeshSurface>();

        // _navMeshSurface.BuildNavMesh();
    }
}