using UnityEngine;

public class HomePlanetButtons : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private GameObject upgradesUI;
    
    private void OnMouseEnter()
    {
        if (!player.landed) return;
        var anim = GetComponent<Animator>();
        anim.Play("Hover Animation", -1, 0f);
    }

    private void OnMouseExit()
    {
        if (!player.landed) return;
        var anim = GetComponent<Animator>();
        anim.Play("Hover End", -1, 0f);
    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("UpgradesShop"))
        {
            upgradesUI.SetActive(true);
        }
    }
}
