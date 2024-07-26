using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIElementsBehaviour : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameScoreText;
    [SerializeField] TextMeshProUGUI finalGameScoreText;
    private int score = 0;

    public void ShowIncrementedScore(int inc)
    {
        score += inc;
        gameScoreText.text = $"Your Score:{score}";
        finalGameScoreText.text = $"Your Score:{score}";
    }
}
