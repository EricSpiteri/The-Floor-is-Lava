using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private float score = 0;

    void Start()
    {
        // Initialize the score text
        UpdateScoreText();
    }

    // Method to increment the score
    public void IncrementScore(float points)
    {
        score += points;
        UpdateScoreText();
    }

    // Method to update the score text
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

     // Method to save the score to PlayerPrefs
     void SaveScore()
    {
        PlayerPrefs.SetFloat("Score", score);
    }

    // Method to load the score from PlayerPrefs
    public void LoadScore()
    {
        score = PlayerPrefs.GetInt("Score", 0);
    }

    // Method to reset the score
    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
        SaveScore();
    }
}