using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDDisplay : MonoBehaviour
{
    // Variables
    [SerializeField] private TextMeshProUGUI ScoreText; // Score text
    private int Score = 0; // Score value

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "SCORE: " + Score.ToString();
    }

    //Method to access score from outside of class. Method increases score.
    public void SetScore(int _score)
    {
        Score += _score;
    }
}
