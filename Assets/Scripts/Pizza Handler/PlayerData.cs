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
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private Animator deliverySuccessText;
    [SerializeField] private Animator deliverySuccessText2;

    private float _finalMoney = 200;
    private string _textColor = "white";
    private float _lerp;
    
    public void IncreaseMoney()
    {
        availableMoney += Random.Range(30, 60);
        deliverySuccessText.Play("Devliery Successful", -1, 0f);
        deliverySuccessText2.Play("Money", -1, 0f);
        _lerp = 0f;
    }
    
    private void Update()
    {
        _lerp += Time.deltaTime / 2f;
        _finalMoney = (int) Mathf.Lerp(_finalMoney, availableMoney, _lerp);
        moneyText.text = _finalMoney.ToString();
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
