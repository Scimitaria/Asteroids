using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public float turn;
    Rigidbody2D rb;

    [SerializeField]
    public float speed;
    public float rotationSpeed = 75f;
    public bool isBoosting = false;


    //runs once at start
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.Find("");
    }
    void FixedUpdate()
    {
        //transform.Rotate(-Vector3.forward * rotationSpeed * turn * Time.deltaTime);
        rb.SetRotation(rb.rotation - (rotationSpeed * Time.deltaTime * turn));

        //transform.Translate(Vector2.up * speed * Time.deltaTime); 
        //if(isBoosting)rb.linearVelocity = transform.up * speed;
        if (isBoosting) rb.AddForce(transform.up * speed);
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
        if (collision.CompareTag("Asteroid"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = Vector2.zero;
        rb.linearVelocity = Vector2.zero;
    }
}
