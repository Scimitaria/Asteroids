using UnityEngine;
using System.Collections.Generic;

public class AsteroidController : MonoBehaviour
{
    [HideInInspector]
    Rigidbody2D rb;
    private float speed;
    [SerializeField]
    public GameObject asteroidChild;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = Random.Range(1, 5);
        //randomDirection = Random.insideUnitCircle.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = transform.up * 5;
    }

    void spawnChildren() {
        Vector3 position = transform.position;
        Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        //HAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHA
        foreach (int e in new List<int>() { 0, 0 })
        {
            rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            Instantiate(asteroidChild, position, rotation);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Bullet(Clone)"){
            switch (gameObject.name)
            {
                case "Largesteroid(Clone)":
                    spawnChildren();
                    FindFirstObjectByType<ScoreManager>().AddScore(10);
                    break;
                case "Asteroid(Clone)":
                    spawnChildren();
                    FindFirstObjectByType<ScoreManager>().AddScore(20);
                    break;
                default:
                    FindFirstObjectByType<ScoreManager>().AddScore(50);
                    break;
            }
            Destroy(gameObject);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
