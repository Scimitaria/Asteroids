using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public float turn;
    Rigidbody2D rb;

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
    }
    void FixedUpdate()
    {
        //transform.Rotate(-Vector3.forward * rotationSpeed * turn * Time.deltaTime);
        rb.SetRotation(rb.rotation - (rotationSpeed * Time.deltaTime * turn));

        //transform.Translate(Vector2.up * speed * Time.deltaTime); 
        //if(isBoosting)rb.linearVelocity = transform.up * speed;
        if(isBoosting) rb.AddForce(transform.up * speed);
    }

    void OnRotate(InputValue value)
    {
        //Debug.Log("turning");
        turn = value.Get<float>();
    }

    void OnMove(InputValue value)
    {
        //Debug.Log("moving");
        if (value.isPressed) isBoosting = true;
        else isBoosting = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Triggered by: " + collision.name);
        if (collision.name == "Asteroid(Clone)")
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = startPosition;
        rb.linearVelocity = Vector2.zero;
        isBoosting = false;
    }
}
