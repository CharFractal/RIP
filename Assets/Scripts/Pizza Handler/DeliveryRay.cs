using UnityEngine;

public class DeliveryRay : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private DropLocationPlanets dropLocationPlanets;
    
    private PlayerMovement _player;

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
