using TMPro;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int restaurantLevel = 1;
    public int pizzasAvailable = 1;
    public int maxPizzaCapacity = 1;
    public int shields;
    public int availableMoney = 200;
    
    [SerializeField] private TMP_Text pizzasText;
    [SerializeField] private GameObject outOfPizzas;
    [SerializeField] private GameObject homeTarget;
    
    private string _textColor = "white";
    
    private void Update()
    {
        if (pizzasAvailable == 0)
        {
            homeTarget.SetActive(true);
            _textColor = "red";
            outOfPizzas.SetActive(true);
        }
        else
        {
            homeTarget.SetActive(false);
            _textColor = "white";
            outOfPizzas.SetActive(false);
        }
        pizzasText.text = "<color=" + _textColor + "><size=100>" + pizzasAvailable + "</size></color>" + "/" + maxPizzaCapacity;
    }
}
