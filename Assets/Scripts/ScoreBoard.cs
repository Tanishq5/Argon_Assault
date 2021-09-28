using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public int Score;

    TMP_Text ScoreText;

    void Start()
    {
        ScoreText = GetComponent<TMP_Text>();
        ScoreText.text = "0";
    }

    public void IncreaseScore(int AmountToIncrease)
    {
        Score += AmountToIncrease;
        ScoreText.text = Score.ToString();
    }
}
