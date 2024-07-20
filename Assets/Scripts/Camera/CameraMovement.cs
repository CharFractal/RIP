using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform homeLocation;
    [SerializeField] private Transform galaxyLocation;
    [SerializeField] private float targetCamSize;
    [SerializeField] private Transform player;
    
    private bool _outsideHomePlanet;
    
    public void TakeOff()
    {
        _outsideHomePlanet = true;
    }

    public void Land()
    {
        _outsideHomePlanet = false;
    }

    private void Update()
    {
        if (_outsideHomePlanet)
        {
            transform.position = Vector3.Lerp(transform.position, galaxyLocation.position, 3f * Time.deltaTime);
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, targetCamSize, 3f * Time.deltaTime);

            var pos = galaxyLocation.position;
            pos.x = player.position.x;
            pos.y = player.position.y;
            galaxyLocation.position = pos;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, homeLocation.position, 3f * Time.deltaTime);
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 5f, 3f * Time.deltaTime);
        }
    }
}
