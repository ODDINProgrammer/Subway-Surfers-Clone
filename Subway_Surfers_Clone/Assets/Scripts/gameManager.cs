using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    bool gameEnded = false;

    [SerializeField] private GameObject ScoreObject;
    [SerializeField] private GameObject FinalScoreObject;
    [SerializeField] private float TimeUntilShift;
    [SerializeField] private float ChangePlayerSpeedAt;
    private bool oneTime = false;

    // Game over routine
    public void EndGame()
    {
        gameEnded = true;
        if (gameEnded)
        {
            ScoreObject.SetActive(false);
            FinalScoreObject.SetActive(true);
            FindObjectOfType<HUDDisplay>().DisplayFinalScore();
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }

    // KeyBoard input handler
    private void Update()
    {
        if (!gameEnded)
        {
            // Update run time
            TimeUntilShift = Mathf.Round(Time.time);
            if (TimeUntilShift % ChangePlayerSpeedAt == 0 && oneTime == false)
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
    }

    public bool ReturnGameStatus()
    {
        return gameEnded;
    }

    public float ReturnChangeSpeedAt()
    {
        return ChangePlayerSpeedAt;
    }

    private void SpeedUp()
    {
        FindObjectOfType<PlayerControl>().SetSpeed();
        oneTime = false;
    }
}
