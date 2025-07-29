using System;
using UnityEngine;

public class MiniMapCameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float cameraOffset;

    private void Update()
    {
        transform.position = player.position + new Vector3(0, cameraOffset, 0);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, player.eulerAngles.y, transform.eulerAngles.z);
    }
}