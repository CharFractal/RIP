using UnityEngine;

public class ShopPurchases : MonoBehaviour
{
    public int shieldsCost;
    public int pizzaCapacityCost;
    public int restaurantUpgradeCost;

    [SerializeField] private PlayerData playerData;

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
        }
    }

    public void BuyShield()
    {
        if (shieldsCost <= playerData.availableMoney)
        {
            playerData.availableMoney -= shieldsCost;
            playerData.shields++;
        }
    }
}
