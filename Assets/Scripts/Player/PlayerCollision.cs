using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject deliverButton;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Home"))
        {
            cameraMovement.Land();
            playerMovement.Land();
            deliverButton.SetActive(true);
        }
    }
}
