using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherPlanet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            Destroy(other);
        }
    }
}
