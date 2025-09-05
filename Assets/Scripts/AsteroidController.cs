using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [HideInInspector]
    Rigidbody2D rb;
    public float speed;
    public Vector2 randomDirection;
    [SerializeField]
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = Random.Range(1, 5);
        randomDirection = Random.insideUnitCircle.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = randomDirection*5;
    }
}
