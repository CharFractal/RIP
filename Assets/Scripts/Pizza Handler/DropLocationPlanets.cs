using UnityEngine;

public class DropLocationPlanets : MonoBehaviour
{
    public int availableDeliveries;
    
    [SerializeField] private Planet[] planets;
    [SerializeField] private GameObject deliveryLocationRing;
    [SerializeField] private Transform player;
    
    private void Start()
    {
        InvokeRepeating(nameof(UpdatePlanets), 2f, 2f);
    }

    public void UpdatePlanets()
    {
        var planet = planets[Random.Range(0, planets.Length)];
        if (planet.orderPending || availableDeliveries > 2) return;

        availableDeliveries++;

        var ring = Instantiate(deliveryLocationRing, player);
        ring.GetComponent<DirectionRing>().targetPlanet = planet.transform.GetChild(2);

        planet.deliveryMeter.fillImage.fillAmount = 0;
        planet.deliveryMeter.gameObject.SetActive(true);
        planet.directionRingPlayer = ring;
        planet.targetArea.gameObject.SetActive(true);
        planet.targetArea.Rotate(0f, 0f, Random.Range(0f, 360f));
        planet.orderPending = true;
    }
}
