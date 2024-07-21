using System;
using System.Collections.Generic;
using UnityEngine;

public class otherPlanet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC") && other.transform.parent != null )
        {
            if (other.transform.parent.GetComponent<NPC>().canKill == false)
            {
                other.transform.parent.GetComponent<NPC>().canKill = true;
            }
            else if (other.transform.parent.GetComponent<NPC>().canKill == true)
            {
                Destroy(other.transform.parent.gameObject);
            }
        }
    }
}
