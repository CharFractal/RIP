using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPurchases : MonoBehaviour
{
    public int shieldsCost;
    public int pizzaCapacityCost;
    public int restaurantUpgradeCost;

    [SerializeField] private PlayerData playerData;
    [SerializeField] private ParticleSystem upgradingParticle;
    [SerializeField] private GameObject deliveryButton;
    [SerializeField] private AudioSource upgradingRestaurant;
    [SerializeField] private GameObject[] shops;
    [SerializeField] private StatsControllerSO armorStats;
    [SerializeField] private StatsControllerSO pizzaCapacity;
    [SerializeField] private StatsControllerSO pizzaShopLevel;
    [SerializeField] private GameObject shieldParent;
    [SerializeField] private GameObject shield;
    
    public void IncreasePizzaCapacity()
    {
        if (pizzaCapacityCost <= playerData.availableMoney)
        {
            playerData.availableMoney -= pizzaCapacityCost;
            playerData.maxPizzaCapacity++;
        }
    }

    public void UpgradeRestaurant()
    {
        if (restaurantUpgradeCost <= playerData.availableMoney)
        {
            playerData.availableMoney -= restaurantUpgradeCost;
            playerData.restaurantLevel++;
            upgradingParticle.Play();
            deliveryButton.SetActive(false);
            StartCoroutine(Delay());
            upgradingRestaurant.Play();
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(4.5f);
        upgradingParticle.Stop();
        deliveryButton.SetActive(true);
        for (int i = 0; i < shops.Length; i++)
        {
            if (i == playerData.restaurantLevel - 1)
            {
                shops[i].SetActive(true);
            }
            else
            {
                shops[i].SetActive(false);
            }
        }
    }
    
    public void BuyShield()
    {
        if (shieldsCost <= playerData.availableMoney)
        {
            playerData.availableMoney -= shieldsCost;
            playerData.shields++;
            Instantiate(shield, shieldParent.transform);
        }
    }
}
