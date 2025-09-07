using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public float turn;
    Rigidbody2D rb;
    public GameObject bulletPrefab;
    private static Transform flame;
    private int bulletCount;
    private ScoreManager scoreManager;
    private LivesManager livesManager;

    [SerializeField]
    public float speed = 3;
    public float rotationSpeed = 150f;
    public bool isBoosting = false;
    private Vector2 startPosition;


    //runs once at start
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        flame = transform.Find("flame");
        scoreManager = FindFirstObjectByType<ScoreManager>();
        livesManager = FindFirstObjectByType<LivesManager>();
    }
    void FixedUpdate()
    {
        //transform.Rotate(-Vector3.forward * rotationSpeed * turn * Time.deltaTime);
        rb.SetRotation(rb.rotation - (rotationSpeed * Time.deltaTime * turn));
        bulletCount = GameObject.FindGameObjectsWithTag("Bullet").Length;

        //transform.Translate(Vector2.up * speed * Time.deltaTime); 
        //if(isBoosting)rb.linearVelocity = transform.up * speed;
        if (isBoosting) rb.AddForce(transform.up * speed);
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
        if (value.isPressed && bulletCount<5)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Triggered by: " + collision.name);
        if(collision.gameObject.CompareTag("Asteroid"))Respawn();
    }

    void Respawn()
    {
        livesManager.AddLife(-1);
        if (livesManager.lives < 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        int score = scoreManager.score;
        scoreManager.AddScore(-(score/5));
        transform.position = startPosition;
        rb.linearVelocity = Vector2.zero;
        isBoosting = false;
    }
    void OnBecameInvisible()
    {
        Respawn();
    }
}
