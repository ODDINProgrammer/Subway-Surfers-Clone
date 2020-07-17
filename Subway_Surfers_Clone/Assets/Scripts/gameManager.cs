using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{   
    private bool oneTime = false;
    bool gameEnded = false;
    private int Score;
    private int HighScore;
    private int PickedUpCoins;

    [SerializeField] private float TimeUntilShift;
    [SerializeField] private float ChangePlayerSpeedAt;


    // Game over routine
    public void EndGame()
    {
        gameEnded = true;
        if (gameEnded)
        {
            // Set High Score
            // HighScore = 0 by default
            if (Score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", Score);
            }
            // Display UI elements
            FindObjectOfType<HUDDisplay>().HideUIElement((int)HUDDisplay.UIElement.CoinUI);
            FindObjectOfType<HUDDisplay>().DisplayUIElement((int)HUDDisplay.UIElement.EngineIcon);
            FindObjectOfType<HUDDisplay>().DisplayUIElement((int)HUDDisplay.UIElement.EndGameScreen);
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }

    private void Update()
    {
        // Timer, which controlls player speeding up
        TimeUntilShift = Mathf.Round(Time.time);
        if (TimeUntilShift % ChangePlayerSpeedAt == 0 && oneTime == false && !gameEnded)
        {
            oneTime = true;
            Invoke("SpeedUp", 1f);
        }
        // Restart game
        if (gameEnded && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        // Terminate app
        if (gameEnded && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    #region Getters
    public bool ReturnGameStatus()
    {
        return gameEnded;
    }

    public float ReturnChangeSpeedAt()
    {
        return ChangePlayerSpeedAt;
    }

    public int GetCoinAmount()
    {
        return PickedUpCoins;
    }

    public int GetScore()
    {
        return Score;
    }

    public int GetHighScore()
    {
        return HighScore;
    }
    #endregion

    #region Setters
    private void SpeedUp()
    {
        FindObjectOfType<PlayerControl>().SetSpeed();
        oneTime = false;
    }

    public void SetCoinAmount()
    {
        PickedUpCoins += 1;
    }

    private void SetHighScore()
    {
        HighScore = Score;
    }

    public void SetScore(int Value)
    {
        Score += Value;
    }
    #endregion





}
