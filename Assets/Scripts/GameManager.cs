using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;

    private float score;
    private int bestScore;
    private bool isGameOver;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateBestScoreUI();
    }

    void Update()
    {
        if (isGameOver) return;

        score += Time.deltaTime;
        UpdateScoreUI();

        if (Mathf.FloorToInt(score) > bestScore)
        {
            bestScore = Mathf.FloorToInt(score);
            PlayerPrefs.SetInt("BestScore", bestScore);
            UpdateBestScoreUI();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + Mathf.FloorToInt(score);
    }

    void UpdateBestScoreUI()
    {
        if (bestScoreText != null)
            bestScoreText.text = "Best: " + bestScore;
    }

    public void GameOver()
    {
        isGameOver = true;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }
}
