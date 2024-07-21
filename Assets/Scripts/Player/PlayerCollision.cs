using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject deliverButton;
    [SerializeField] private GameObject directionRing;
    [SerializeField] private PlayerData playerData;
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("DropLocation"))
            directionRing.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("DropLocation"))
        {
            directionRing.SetActive(false);
        }
        
        if (col.CompareTag("Home"))
        {
            cameraMovement.Land();
            playerMovement.Land();
            deliverButton.SetActive(true);
            playerData.pizzasAvailable = playerData.maxPizzaCapacity;
        }
    }
}
