using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI ballsText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button restartButton;
    private int score = 0;
    private int scoreCheck = 0;
    private int newBallValue = 500;
    private int ballsRemaining = 3;
    public bool isGameActive;
    public bool isBallActive;

    void Start() {
        isGameActive = true;
    }

    void Update() {
        if(ballsRemaining == 0 && !isBallActive) {
            GameOver();
        }
    }
    // Increase score by parameter amount
    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreCheck += scoreToAdd;
        scoreText.text = "Score: " + score;
        if(scoreCheck >= newBallValue) {
            UpdateBallCount(1);
            scoreCheck -= newBallValue;
        }
    }

    // Change number of balls remaining for player
    public void UpdateBallCount(int ballChange) {
        ballsRemaining += ballChange;
        ballsText.text = "Balls: " + ballsRemaining;
    }

    private void GameOver() {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
