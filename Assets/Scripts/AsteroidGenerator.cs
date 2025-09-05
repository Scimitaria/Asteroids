using System.Collections;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour{
    private static WaitForSeconds _waitForSeconds1 = new WaitForSeconds(1f);
    public GameObject asteroidPrefab;
    public Vector2 spawnStart;
    public float spawnDistance;
    public int numOfAsteroids;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        IEnumerator method = SpawnAsteroids();
        StartCoroutine(method);
    }

    Vector2 EdgePosition(){
        System.Random random = new System.Random();
        int width = Screen.width;
        int height = Screen.height;
        switch (random.Next(4)){
            case 0: return new Vector2(random.Next(1, 3), random.Next(1, height));
            case 1: return new Vector2(random.Next(width - 3, width), random.Next(1, height));
            case 2: return new Vector2(random.Next(1, width), random.Next(1, 3));
            case 3: return new Vector2(random.Next(1, width), random.Next(height-3, height));
            default:
                Debug.Log("Error: spawn position out of bounds");
                return new Vector2(1, 1);
        }
    }

    IEnumerator SpawnAsteroids(){
        while (numOfAsteroids-- > 0){
            Vector2 spawnPosition = EdgePosition();
            Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity, transform);
            //spawnStart += Vector2.right * spawnDistance;
            yield return _waitForSeconds1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
