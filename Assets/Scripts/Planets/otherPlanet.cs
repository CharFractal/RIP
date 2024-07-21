using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class otherPlanet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        Destroy(other);
        Debug.Log("wow anadar");
    }

    private void Update()
    {
        Debug.Log("wow bahar");
    }
}
