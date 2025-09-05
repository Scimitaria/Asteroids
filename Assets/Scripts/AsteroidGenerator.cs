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
        Vector2 lowerLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
        Vector2 upperRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));
        float width = upperRight.x - lowerLeft.x;
        float height = upperRight.y - lowerLeft.y;
        switch (random.Next(4)){
            case 0: return new Vector2(Random.Range(1, 3)-width/2, Random.Range(1, height)-height/2);
            case 1: return new Vector2(Random.Range(width - 3, width)-width/2, Random.Range(1, height)-height/2);
            case 2: return new Vector2(Random.Range(1, width)-width/2, Random.Range(1, 3)-height/2);
            case 3: return new Vector2(Random.Range(1, width)-width/2, Random.Range(height-3, height)-height/2);
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
