using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class WayPoints : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float speed = 2.0f;

    private int currentWaypoint = 0;

    void Update()
    {
        if (waypoints.Length == 0)
            return;

        transform.position = Vector3.Lerp(transform.position, waypoints[currentWaypoint].position, Time.deltaTime * speed);

        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }
}
        
