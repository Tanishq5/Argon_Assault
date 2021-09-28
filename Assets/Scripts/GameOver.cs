using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] ScoreBoard SB;

    TMP_Text GameOverScore;

    void Update()
    {
        GameOverScore = GetComponent<TMP_Text>();
        FinalScore();
    }

    private void FinalScore()
    {
        GameOverScore.text = "SCORE : " + SB.Score.ToString();
    }
}
