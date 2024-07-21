using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryMeter : MonoBehaviour
{
    public Image fillImage;
    
    [SerializeField] private Planet planet;
    [SerializeField] private Transform deliveryText;
    [SerializeField] private Transform pivot;
    
    private PlayerMovement _playerMovement;
    private PlayerData _playerData;
    
    private void Start()
    {
        _playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        _playerData = FindObjectOfType<PlayerData>();
    }

    private void Update()
    {
        if (_playerData.pizzasAvailable == 0)
            GetComponent<Collider2D>().enabled = false;
        else
            GetComponent<Collider2D>().enabled = true;
        
        pivot.transform.up = Vector3.up;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        fillImage.fillAmount += Time.deltaTime / 2f;

        deliveryText.rotation = Quaternion.identity;
        
        if (fillImage.fillAmount >= 1f)
        {
            _playerMovement.DropPizza(planet.locationInPlane, planet);
            fillImage.fillAmount = 0f;
            Destroy(planet.directionRingPlayer);
            gameObject.SetActive(false);
            _playerMovement.directionRing.SetActive(false);
        }
    }
}
