using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool landed;
    public float speed;
    public bool droppingPizza;
    public Planet tempPlanet;
    public GameObject directionRing;
    
    [SerializeField] private Transform mouseLocation;
    [SerializeField] private Transform homePlanet;
    [SerializeField] private Animator deliveringAnimation;
    [SerializeField] private Transform deliveryRay;
    [SerializeField] private Transform pivot;
    [SerializeField] private AudioSource pizzaDeliverAudio;
    [SerializeField] private AudioSource shipMoving;
    [SerializeField] private AudioSource pickUpPizzaAudio;
    
    private bool _allowMovement;
    private Vector3 _initPosition;
    private Transform _targetDeliveryPlanet;
    private bool _firstTrigger;
    
    public void DropPizza(Transform targetPlanet, Planet planet)
    {
        pizzaDeliverAudio.Play();
        deliveringAnimation.transform.parent = null;
        tempPlanet = planet;
        _targetDeliveryPlanet = targetPlanet;
        deliveryRay.LookAt(targetPlanet);
        droppingPizza = true;
        deliveringAnimation.Play("Deliver", -1, 0f);
    }
    
    private void Start()
    {
        _initPosition = transform.position;
    }

    public void TakeOff()
    {
        directionRing.SetActive(true);
        _allowMovement = true;
        landed = false;
        shipMoving.Play();
    }

    public void Land()
    {
        directionRing.SetActive(false);
        _allowMovement = false;
        transform.DOMove(_initPosition, .3f);
        landed = true;
        shipMoving.Stop();
        if (_firstTrigger)
            pickUpPizzaAudio.Play();
        else
            _firstTrigger = true;
    }

    private void Update()
    {
        pivot.parent = null;
        pivot.position = transform.position;
        pivot.forward = Vector3.up;
        if (droppingPizza && _targetDeliveryPlanet != null)
        {
            deliveryRay.position = transform.position;
            deliveryRay.LookAt(_targetDeliveryPlanet);
            speed = .3f;
        }
        else
        {
            speed = 2f;
        }
        
        if (Vector3.Distance(homePlanet.position, transform.position) > 5f)
        {
            homePlanet.GetComponent<Collider2D>().enabled = true;
        }
        
        if (_allowMovement)
        {
            //_rb2D.velocity = transform.forward * speed * 5f;
            transform.position = Vector3.Lerp(transform.position, mouseLocation.position, speed * Time.deltaTime);
            LookAtMouse();
        }
#if WASD
        else if (_allowInput && _allowMovement)
        {
            _rb2D.velocity = transform.up * speed;
        }
        
        if (newPlayerPosition.position.y < transform.position.y)
        {
            _allowInput = true;
        }
        
        if (_allowInput)
        {
            
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.DORotate(new Vector3(0f, 0f, 90f), .1f);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.DORotate(new Vector3(0f, 0f, -90f), .1f);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.DORotate(new Vector3(0f, 0f, 180f), .1f);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.DORotate(new Vector3(0f, 0f, 0f), .1f);
            }
        }
        
#endif
    }

    private void LookAtMouse()
    {
        var mousePosition = Input.mousePosition;
        var worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y
            , 10f));

        worldPosition.z = 0f;
        mouseLocation.position = worldPosition;

        transform.LookAt(mouseLocation);
    }
}
