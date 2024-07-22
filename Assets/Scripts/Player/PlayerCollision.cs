using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject deliverButton;
    [SerializeField] private GameObject directionRing;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private GameObject gameOverUI;
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("DropLocation"))
            directionRing.SetActive(true);
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
        gameOverUI.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Police"))
        {
            explosion.gameObject.SetActive(true);
            directionRing.SetActive(false);
            playerMovement.enabled = false;
            explosion.gameObject.transform.parent = null;
            explosion.Play();
            Destroy(transform.GetChild(0).gameObject);
            StartCoroutine(Delay());
        }
        
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
