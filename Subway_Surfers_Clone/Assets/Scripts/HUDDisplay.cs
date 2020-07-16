using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDDisplay : MonoBehaviour
{
    // Variables
    private int Score = 0; 
    [SerializeField] private TextMeshProUGUI FinalScore; 
    [SerializeField] private GameObject EngineIcon;
    [SerializeField] private GameObject EndGameScreen;

    public enum UIElement
    {
        EngineIcon = 1,
        EndGameScreen = 2,
    }
    // Update is called once per frame
    void Update()
    {
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

    public void DisplayUIElement(int index)
    {
        switch (index)
        {
            default:
                break;
            // Activate EngineIcon
            case 1:
                EngineIcon.SetActive(true);
                break; 
            case 2:
                EndGameScreen.SetActive(true);
                DisplayFinalScore();
                break;
        }
    }

    
}
