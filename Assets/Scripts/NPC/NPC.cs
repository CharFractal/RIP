using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPC : MonoBehaviour
{
    private randomNPCSpawner Spawner;
    private int maxPlanets = 0;
    public int[] pathway = new int[2];
    [SerializeField] private GameObject Empty = default;
    private GameObject MyEmpty;

    void Start()
    {
        Spawner = GameObject.FindWithTag("spawner").GetComponent<randomNPCSpawner>();
        maxPlanets = Spawner.otherPlantsPositions.Length;
        Debug.Log(maxPlanets);
        int rand = Random.Range(0, maxPlanets);
        pathway[0] = Random.Range(0, maxPlanets);
        if (maxPlanets <= 1)
        {
            Debug.LogWarning("Planets are less then 1, kya travel karega?");
        }
        else if (rand == pathway[0] && rand == maxPlanets - 1)
        {
            pathway[1] = rand - 1;
        }
        else if (pathway[0] == rand && rand == 0)
        {
            pathway[1] = Random.Range(1, maxPlanets);
        }
        else if (pathway[0] == pathway[1])
        {
            Destroy(gameObject);
        }
        Debug.Log(pathway[0]);
        Debug.Log(pathway[1]);
        gameObject.transform.position = Spawner.otherPlantsPositions[pathway[0]];
        MyEmpty = Instantiate(Empty,
            new Vector3(Spawner.otherPlantsPositions[pathway[0]].x, Spawner.otherPlantsPositions[pathway[0]].y, 0f), Empty.transform.rotation);
        MyEmpty.name = gameObject.name.Substring(0, 3) + " Empty";
    }

    private void Update()
    {
        transform.LookAt(MyEmpty.transform);
        transform.DOMove(MyEmpty.transform.position, Spawner.cycleLength).SetEase(Ease.InOutSine);
    }
}
