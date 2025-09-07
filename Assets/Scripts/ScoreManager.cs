using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int score;
    private int prevScore;
    private LivesManager livesManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        scoreText.text = "000000";
        livesManager = FindFirstObjectByType<LivesManager>();
    }

    void UpdateScore()
    {
        scoreText.text = score.ToString("D6");
    }
    public void AddScore(int points)
    {
        int prevScore = score;

        score += points;
        UpdateScore();

        //check if the hundreds place went up
        if (int.Parse(score.ToString("D6")[3].ToString()) > int.Parse(prevScore.ToString("D6")[3].ToString())) livesManager.AddLife(1);
    }
}
