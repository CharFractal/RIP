using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Sequence = DG.Tweening.Sequence;

public class EmptyBeingFollowed : MonoBehaviour
{
    // [SerializeField]private 
    private randomNPCSpawner Spawner;
    private NPC MyNPCShip;
    private float exaguration = 7.8f;
    void Start()
    {
        MyNPCShip = GameObject.Find(gameObject.name.Substring(0, 3) + " Ship").GetComponent<NPC>();
        Spawner = GameObject.FindWithTag("spawner").GetComponent<randomNPCSpawner>();
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMove(middle(Spawner.otherPlantsPositions[MyNPCShip.pathway[0]],
            Spawner.otherPlantsPositions[MyNPCShip.pathway[1]], exaguration), Spawner.cycleLength).SetEase(Ease.InOutSine));
        mySequence.Append(transform.DOMove(Spawner.otherPlantsPositions[MyNPCShip.pathway[1]], Spawner.cycleLength).SetEase(Ease.InOutSine));
    }

    Vector2 middle(Vector2 p1, Vector2 p2, float distance)
    {
        Vector2 midpoint = (p1 + p2) / 2;
        Vector2 direction = p2 - p1;
        Vector2 perpendicular = new Vector2(-direction.y, direction.x);
        perpendicular = Vector3.Normalize(perpendicular);
        perpendicular *= distance;
        Vector2 movedPoint = midpoint + perpendicular;
        return movedPoint + (p2 * 0.5f);
    }
}
