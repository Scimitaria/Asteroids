using System.Collections;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour{
    [HideInInspector]
    private static Vector2 lowerLeft,upperRight,center,spawnPosition,spawnDirection;
    private static float width,height,centerX,centerY,spawnDistance;
    private static WaitForSeconds _waitForSeconds1 = new WaitForSeconds(1f);
    [SerializeField]
    public GameObject asteroidPrefab;
    //public int numOfAsteroids;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IEnumerator method = SpawnAsteroids();
        StartCoroutine(method);
        /*
        lowerLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
        upperRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        width = upperRight.x - lowerLeft.x;
        height = upperRight.y - lowerLeft.y;
        centerX = width / 2f;
        centerY = height / 2f;
        center = new Vector2(centerX, centerY);
        */
    }
/*      
System.Random random = new System.Random();
switch (random.Next(4)){
    case 0: return new Vector2(Random.Range(1, 3) - width / 2, Random.Range(1, height) - height / 2);
    case 1: return new Vector2(Random.Range(width - 3, width) - width / 2, Random.Range(1, height) - height / 2);
    case 2: return new Vector2(Random.Range(1, width) - width / 2, Random.Range(1, 3) - height / 2);
    case 3: return new Vector2(Random.Range(1, width) - width / 2, Random.Range(height - 3, height) - height / 2);
    default:
        Debug.Log("Error: spawn position out of bounds");
        return new Vector2(1, 1);
}
*/

    IEnumerator SpawnAsteroids(){
        spawnDistance = 10;
        Vector2 toCenter;
        float angle;
        Quaternion rotation;
        while (true)
        {
            spawnDirection = Random.insideUnitCircle.normalized;
            spawnPosition = spawnDirection * spawnDistance;
            toCenter = (Vector2.zero - (Vector2)spawnPosition).normalized;
            angle = Mathf.Atan2(toCenter.y, toCenter.x) * Mathf.Rad2Deg - 90f + Random.Range(-45f, 45f);
            rotation = Quaternion.Euler(0, 0, angle);
            Instantiate(asteroidPrefab, spawnPosition, rotation);
            yield return _waitForSeconds1;
        }
    }
}
