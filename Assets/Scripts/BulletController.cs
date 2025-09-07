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
        rb.linearVelocity = transform.up * 7;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Asteroid"))Destroy(gameObject);
    }
    void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
}
