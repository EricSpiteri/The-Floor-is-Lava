using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager:MonoBehaviour
{
    private int score;
    public TMP_Text scoreText;

    public void AddPoint()
    {
        score = score + 1;
        scoreText.text = score.ToString();
    }
}

