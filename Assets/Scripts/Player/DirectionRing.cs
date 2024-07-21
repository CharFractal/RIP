using UnityEngine;

public class DirectionRing : MonoBehaviour
{
    public Transform directionRing;
    public Transform targetPlanet;

    private void Update()
    {
        directionRing.LookAt(targetPlanet);
    }
}
