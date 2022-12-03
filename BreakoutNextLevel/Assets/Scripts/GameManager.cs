using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;

public class GameManager : MonoBehaviour
{
    public GameObject[] hearts;
    public GameObject gameOverPanel, WinnerPanel, PausePanel;
    public int lives, score, brickcountr;
    public Text scoreText, FinalLevelScoreText, WinScoreText;
    public bool gameOver, win;

    public static bool GamePaused = false;


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;

        brickcountr = GameObject.FindGameObjectsWithTag("brick").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Continue();
            }
            else
            {
                PausePanel.SetActive(true);
                Time.timeScale = 0f;
                GamePaused = true;
            }
        }
    }

    public void Continue()
    {
       PausePanel.SetActive(false);
       Time.timeScale = 1f;
       GamePaused = false;

    }

    public void UpdateLives(int livesCountr)
    {
        lives += livesCountr;

        if (lives < 1)
        {
            Destroy(hearts[0].gameObject);
            lives = 0;
            GameOver();
        } else if (lives < 2)
        {
            Destroy(hearts[1].gameObject);
        }
        else if (lives < 3)
        {
            Destroy(hearts[2].gameObject);
        }

    }

    public void UpdateScore(int scoreCountr)
    {
        score += scoreCountr;
        scoreText.text = "Score: " + score;
    }

    public void UpdateBrickCount()
    {
        brickcountr--;
        if(brickcountr <= 0)
        {
            Winning();
        }
    }

    void Winning()
    {
        win = true;
        WinnerPanel.SetActive(true);
        WinScoreText.text = "Score: " + score + "  Lives: " + lives + "\nCoins: " + score*lives;
        PlayerPrefs.SetInt("SavedInteger", (score * lives) + PlayerPrefs.GetInt("SavedInteger"));
    }

    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        FinalLevelScoreText.text = "Score: " + score;
    }

    public void GiveUp()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void Levelpicker()
    {
        SceneManager.LoadScene("LevelPicker");
    }

    //levelScenes
    public void levelone()
    {
        SceneManager.LoadScene("levelone");
    }

    public void leveltwo()
    {
        SceneManager.LoadScene("leveltwo");
    }
}