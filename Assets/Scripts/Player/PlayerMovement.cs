using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform newPlayerPosition;
    [SerializeField] private float speed;
    [SerializeField] private Transform mouseLocation;
    
    private Rigidbody2D _rb2D;
    private bool _allowMovement;
    private bool _allowInput;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    public void TakeOff()
    {
        _allowMovement = true;
    }

    private void Update()
    {
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
