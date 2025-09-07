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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Bullet(Clone)"){
            if (gameObject.name == "Largesteroid(Clone)" || gameObject.name == "Asteroid(Clone)")
            {
                Vector3 position = transform.position;
                Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
                foreach (int e in new List<int>() { 0, 0 }){
                    rotation = Quaternion.Euler(0, 0, Random.Range(0,360));
                    Instantiate(asteroidChild, position, rotation);
                }
            }
            /*
            Vector2 spawnPosition = transform.position;
            GameObject fab = new GameObject("Asteroid(Clone)");
            Quaternion rotation;
            //HAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHA
            foreach (int e in new List<int>() { 0, 0 })
            {
                rotation = Quaternion.Euler(0, 0, Random.Range(0,360));
                Instantiate(fab, spawnPosition, rotation);
            }
            */
            Destroy(gameObject);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
