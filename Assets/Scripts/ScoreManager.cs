using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    public static event Action<int> OnScoreChanged;
    public static event Action OnPlayerWin;
    public int targetScore = 11;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
        
    public void AddScore (int amount)
    {
        score += amount;
        UpdateScore();
        OnScoreChanged?.Invoke(score);
    }
    public void UpdateScore()
    {
        if(scoreText != null)
        {
            scoreText.text = "Coins " + score;
        }
    }
}