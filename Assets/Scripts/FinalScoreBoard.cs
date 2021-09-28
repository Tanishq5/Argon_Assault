using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreBoard : MonoBehaviour
{
    [SerializeField] ScoreBoard SB;
    [SerializeField] TMP_Text FinalScoreText;

    void Update()
    {
        FinalScoreText = GetComponent<TMP_Text>();
        FinalScore();
    }

    private void FinalScore()
    {
        FinalScoreText.text = "Score: " + SB.Score.ToString();
    }
}
