using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Police : MonoBehaviour
{
    public List<Transform> Waypoints = new List<Transform>();
    [SerializeField]private float Cycletime = 0f;

    void Start()
    {
        if (Waypoints == null || Waypoints.Count < 2)
        {
            Debug.LogError("Not enough Waypoints. least two Waypoints CHahiye");
            return;
        }
        Vector3[] pathPositions = new Vector3[Waypoints.Count];
        for (int i = 0; i < Waypoints.Count; i++)
        {
            pathPositions[i] = Waypoints[i].position;
        }
        Debug.Log("Path positions: " + string.Join(", ", pathPositions));
        transform.DOPath(pathPositions, Cycletime, PathType.CatmullRom) 
            .SetOptions(true) 
            .SetLoops(-1, LoopType.Restart) 
            .SetEase(Ease.Linear)
            .SetLookAt(0f) 
            .OnWaypointChange(OnWaypointChanged); 
    }

    void OnWaypointChanged(int waypointIndex)
    {
        Debug.Log("Reached waypoint: " + waypointIndex);
    }
}
