using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// The UIManager class handles all the UI elements, including score and lives display,
/// and shows the game over screen when necessary.
/// </summary>
public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public Text scoreText;
    public Text livesText;
    public Text finalScoreText;
    public GameObject gameOverScreen;
    public GameObject pauseMenu;
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

    private void Start()
    {
        scoreText.text = GameManager.Instance.score.ToString();
        livesText.text = GameManager.Instance.playerLives.ToString();
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateLivesText(int lives)
    {
        livesText.text = lives.ToString();
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        finalScoreText.text = GameManager.Instance.score.ToString();
    }
    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Demo Game Scene");
        GameManager.Instance.score = 0;
        GameManager.Instance.playerLives = 3;
        UpdateLivesText(3);
        UpdateScoreText(0);
        pauseMenu.SetActive(false);
        gameOverScreen.SetActive(false);
    }
    public void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

}
