using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    bool gameEnded = false;

    [SerializeField] private GameObject ScoreObject;
    [SerializeField] private GameObject FinalScoreObject;

    // Game over routine
    public void EndGame()
    {
        gameEnded = true;
        if (gameEnded)
        {
            Debug.Log("GAME OVER");
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
        // Restart game
        if (gameEnded && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        // Terminate app
        if(gameEnded && Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Terminating App");
            Application.Quit();
        }
    }

    public bool GameOver()
    {
        return gameEnded;
    }
}
