using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceStation : MonoBehaviour
{
    private GameObject[] policeWale;
    private Police[] policeWaloKiPolice; 
    public GameObject Lead;
    
    void Start()
    {
        policeWaloKiPolice = new Police[GameObject.FindGameObjectsWithTag("Police").Length];
        policeWale = GameObject.FindGameObjectsWithTag("Police");
        for (int i = 0; i < policeWale.Length; i++)
        {
            var what = policeWale[i].GetComponent<Police>();
            policeWaloKiPolice[i] = what; 
            Debug.Log(policeWaloKiPolice[i].name);
        }
    }

    public void reportToThana(GameObject lead)
    {
        Lead = lead;
        Debug.Log(lead.name + " Leads");
        lead.GetComponent<Police>().state = Police.State.Shooting;
    }
}
