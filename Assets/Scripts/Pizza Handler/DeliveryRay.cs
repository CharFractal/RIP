using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryRay : MonoBehaviour
{
    private PlayerMovement _player;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private DropLocationPlanets dropLocationPlanets;
    
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void DeliveryDone()
    {
        _player.droppingPizza = false;
        _player.directionRing.SetActive(true);
        if (playerData.pizzasAvailable > 0) playerData.pizzasAvailable--;
        _player.tempPlanet.DeliveredPizza();
        dropLocationPlanets.availableDeliveries--;
    }
}
