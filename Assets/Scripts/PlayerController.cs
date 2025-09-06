using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public float turn;
    Rigidbody2D rb;
    public GameObject bulletPrefab;
    private static Transform flame;

    [SerializeField]
    public float speed = 2;
    public float rotationSpeed = 75f;
    public bool isBoosting = false;
    private Vector2 startPosition;


    //runs once at start
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        flame = transform.Find("flame");
    }
    void FixedUpdate()
    {
        //transform.Rotate(-Vector3.forward * rotationSpeed * turn * Time.deltaTime);
        rb.SetRotation(rb.rotation - (rotationSpeed * Time.deltaTime * turn));

        //transform.Translate(Vector2.up * speed * Time.deltaTime); 
        //if(isBoosting)rb.linearVelocity = transform.up * speed;
        if(isBoosting) rb.AddForce(transform.up * speed);
        flame.gameObject.SetActive(isBoosting);
    }

    void OnRotate(InputValue value)
    {
        //Debug.Log("turning");
        turn = value.Get<float>();
    }

    void OnMove(InputValue value)
    {
        //Debug.Log("moving");
        isBoosting = value.isPressed;
    }
    void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Triggered by: " + collision.name);
        if (collision.name == "Asteroid(Clone)") Respawn();
    }

    void Respawn()
    {
        transform.position = startPosition;
        rb.linearVelocity = Vector2.zero;
        isBoosting = false;
    }
    void OnBecameInvisible()
    {
        Respawn();
    }
}
