using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public Text livesText;
    public int lives;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lives = 5;
        livesText.text = "5";
    }

    void UpdateLives()
    {
        livesText.text = lives.ToString();
    }
    public void AddLife(int life)
    {
        lives += life;
        UpdateLives();
    }
}
