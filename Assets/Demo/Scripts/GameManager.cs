using UnityEngine;

/// <summary>
/// The GameManager class is responsible for controlling the game's state, including score management,
/// player lives, and the overall game flow (start, pause, game over).
/// It uses the Singleton pattern to ensure only one instance exists.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int playerLives = 3;
    public int score = 0;
    public UIManager uiManager;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScore(int points)
    {
        score += points;
        uiManager.UpdateScoreText(score);
    }

    public void PlayerHit()
    {
        playerLives--;
        uiManager.UpdateLivesText(playerLives);

        if (playerLives <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        uiManager.ShowGameOverScreen();
    }
}
