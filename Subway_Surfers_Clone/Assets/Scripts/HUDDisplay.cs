using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDDisplay : MonoBehaviour
{
    // Variables
    [SerializeField] private TextMeshProUGUI ScoreText; 
    [SerializeField] private TextMeshProUGUI HighScoreText; 
    [SerializeField] private TextMeshProUGUI CoinText; 
    [SerializeField] private GameObject EndGameScreen;

    public enum UIElement
    {
        EngineIcon = 1,
        EndGameScreen = 2,
        CoinUI = 3,
    }
    // Update is called once per frame
    void Update()
    {
        CoinText.text = FindObjectOfType<gameManager>().GetCoinAmount().ToString();
    }

    public void DisplayScores()
    {
        ScoreText.text = FindObjectOfType<gameManager>().GetScore().ToString();
        HighScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void DisplayUIElement(int index)
    {
        switch (index)
        {
            default:
                break;
            case 1:
                break; 
            // Activate EndGame UI
            case 2:
                EndGameScreen.SetActive(true);
                DisplayScores();
                break;
        }
    }

    public void HideUIElement(int index)
    {
        switch (index)
        {
            default:
                break;
            // Deactivate CoinUI
            case 3:
                GameObject.Find("CoinCounter").SetActive(false);
                break;
            
        }
    }
    
}
