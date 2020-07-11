using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDDisplay : MonoBehaviour
{
    // Variables
    [SerializeField] private TextMeshProUGUI ScoreText; // Score text
    private int Score = 0;                              // Score value
    [SerializeField] private TextMeshProUGUI FinalScore;
    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "SCORE: " + Score.ToString();
    }

    public void DisplayFinalScore()
    {
        FinalScore.text = "Your Score: " + Score.ToString();
    }
    //Method to access score from outside of class. Method increases score.
    public void SetScore(int _score)
    {
        Score += _score;
    }
}
