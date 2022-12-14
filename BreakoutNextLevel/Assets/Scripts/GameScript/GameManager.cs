using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] hearts;
    public GameObject gameOverPanel, WinnerPanel, PausePanel, areyousurePanel;
    public int lives, score, brickcountr, unlockLevel;
    public Text scoreText, FinalLevelScoreText, WinScoreText;
    public bool gameOver, win;
    public AudioSource loserSound1, loserSound2, winnerSound1, winnerSound2, loseHeartSound;

    //for skin
    [SerializeField] private SpriteRenderer Paddle;
    [SerializeField] private SpriteRenderer Ball;

    public static bool GamePaused = false;

    private void Awake()
    {
        //adding skins
        Paddle.sprite = SkinManager.equippedSkin;
        Ball.sprite = BALLSkinManager.BALLequippedSkin;
    }

    void Start()
    {
        scoreText.text = "SCORE: " + score;
        brickcountr = GameObject.FindGameObjectsWithTag("brick").Length;

        unlockLevel = SceneManager.GetActiveScene().buildIndex + 1;
    }

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
                if (gameOver == false && win == false)
                {
                    PausePanel.SetActive(true);
                    Time.timeScale = 0f;
                    GamePaused = true;
                }
            }
        }
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void accidentalQuit()
    {
        areyousurePanel.SetActive(false);
    }

    public void failSafeLeaveGame()
    {
        areyousurePanel.SetActive(true);
    }

    public void UpdateLives(int livesCountr)
    {
        lives += livesCountr;

        if (lives < 1)
        {
            Destroy(hearts[0].gameObject);
            lives = 0;
            GameOver();
        }
        else if (lives < 2)
        {
            loseHeartSound.Play();
            Destroy(hearts[1].gameObject);
        }
        else if (lives < 3)
        {
            loseHeartSound.Play();
            Destroy(hearts[2].gameObject);
        }
    }

    public void UpdateScore(int scoreCountr)
    {
        score += scoreCountr;
        scoreText.text = "SCORE: " + score;
    }

    public void UpdateBrickCount()
    {
        brickcountr--;
        if (brickcountr <= 0)
        {
            Winning();
        }
    }

    void Winning()
    {
        winnerSound1.Play();
        winnerSound2.Play();
        win = true;
        WinnerPanel.SetActive(true);
        WinScoreText.text = "Score: " + score + "  Lives: " + lives + "\nCoins: " + score * lives;
        PlayerPrefs.SetInt("SavedCoins", (score * lives) + PlayerPrefs.GetInt("SavedCoins"));
        if (win) {
        if (unlockLevel > PlayerPrefs.GetInt("currentStateAt"))
            {
                PlayerPrefs.SetInt("currentStateAt", unlockLevel);
            }
        }
    }

    void GameOver()
    {
        loserSound1.Play();
        loserSound2.Play();
        gameOver = true;
        PausePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        FinalLevelScoreText.text = "Score: " + score;
    }

    public void GiveUp()
    {
        GameOver();
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
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

    public void levelthree()
    {
        SceneManager.LoadScene("levelthree");
    }
}