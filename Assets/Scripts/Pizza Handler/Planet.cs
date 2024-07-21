using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public GameObject directionRingPlayer;
    public Transform targetArea;
    public bool orderPending;
    public DeliveryMeter deliveryMeter;
    
    [SerializeField] public Transform locationInPlane;
    [SerializeField] private GameObject[] money;
    
    private void Start()
    {
        var pos = locationInPlane.position;
        pos.z = 0f;
        locationInPlane.position = pos;
    }

    public void DeliveredPizza()
    {
        orderPending = false;
        // foreach (var moneyObj in money)
        // {
        //     moneyObj.SetActive(true);
        // }
    }
}
