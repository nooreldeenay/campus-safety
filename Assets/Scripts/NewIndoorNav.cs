using System;
using System.Collections.Generic;
using System.Linq;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.ARFoundation;

public class NewIndoorNav : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private ARTrackedImageManager trackedImageManager;
    [SerializeField] private GameObject trackedImagePrefab;
    [SerializeField] private LineRenderer lineRenderer;

    private List<NavigationTarget> _navigationTargets = new List<NavigationTarget>();
    private NavMeshSurface _navMeshSurface;
    private NavMeshPath _navMeshPath;

    private GameObject _navigationBase;

    private float _playerHeight = 1.5f;

    private void Start()
    {
        _navMeshPath = new NavMeshPath();

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Update()
    {
        if (_navigationBase != null && _navigationTargets.Count > 0 && _navMeshSurface != null)
        {
            // _navMeshSurface.BuildNavMesh();
            NavMesh.CalculatePath(player.position, _navigationTargets[0].transform.position, NavMesh.AllAreas,
                _navMeshPath);

            if (_navMeshPath.status == NavMeshPathStatus.PathComplete)
            {
                lineRenderer.positionCount = _navMeshPath.corners.Length;
                lineRenderer.SetPositions(_navMeshPath.corners);
            }
            else
            {
                lineRenderer.positionCount = 0;
            }
        }
    }

    private void OnEnable()
    {
        trackedImageManager.trackablesChanged.AddListener(OnChanged);
    }

    private void OnDisable()
    {
        trackedImageManager.trackablesChanged.RemoveListener(OnChanged);
    }

    private void OnChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            Debug.Log("Added new Image");
            _navigationBase = Instantiate(trackedImagePrefab);

            _navigationTargets.Clear();
            _navigationTargets = _navigationBase.transform.GetComponentsInChildren<NavigationTarget>().ToList();
            _navMeshSurface = _navigationBase.GetComponentInChildren<NavMeshSurface>();
        }

        foreach (var updatedImage in eventArgs.updated)
        {
            Debug.Log("Updated");

            _navigationBase.transform.SetPositionAndRotation(
                updatedImage.transform.position + Vector3.up * -_playerHeight,
                Quaternion.Euler(0, updatedImage.pose.rotation.eulerAngles.y, 0));
        }

        foreach (var removedImage in eventArgs.removed)
        {
        }
    }
}