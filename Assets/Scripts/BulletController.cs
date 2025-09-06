using UnityEngine;

public class BulletController : MonoBehaviour
{
    [HideInInspector]
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = transform.up * 5;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Asteroid(Clone)")Destroy(gameObject);
    }
}
