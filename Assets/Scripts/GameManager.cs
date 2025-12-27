using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;

    private float score;
    private bool isGameOver;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (isGameOver) return;

        score += Time.deltaTime;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }

    public void GameOver()
    {
        isGameOver = true;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }
}
