using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        scoreText.text = "000000";
    }

    void UpdateScore()
    {
        scoreText.text = score.ToString("D6");
    }
    public void AddScore(int points)
    {
        score += points;
        UpdateScore();
    }
}
