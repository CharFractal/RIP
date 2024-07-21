using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class randomNPCSpawner : MonoBehaviour
{
    private GameObject[] otherPlanetsinScene = default;
    public Vector2[] otherPlantsPositions = default;
    public int time = 2;
    private int timepool = 0;
    public List<GameObject> NPCShips = new List<GameObject>();
    [SerializeField] private GameObject NPCShip = default;
    public float cycleLength = 2;
    private int timerCounter = 0;
    void Start()
    {
        otherPlanetsinScene = GameObject.FindGameObjectsWithTag("otherPlanet");
        otherPlantsPositions = new Vector2[otherPlanetsinScene.Length];
        for(int i = 0; i < otherPlanetsinScene.Length; i++)
        {
            otherPlantsPositions[i] = otherPlanetsinScene[i].transform.position;
        }

        timepool = time * 50;
        Debug.Log("Timer Started");
    }
    
    private void FixedUpdate()
    {
        if (timepool == 0)
        {
            timepool = time * 50;
            Debug.Log("timer endeed");
            NPCShips.Add(Instantiate(NPCShip, transform));
            NPCShips.ElementAt(timerCounter).name = timerCounter.ToString("D3") + " Ship";
            timerCounter++;
        }
        else
        {
            timepool--;
        }
    }
}
