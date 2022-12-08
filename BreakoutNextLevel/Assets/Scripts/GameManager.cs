using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] hearts;
    public GameObject gameOverPanel, WinnerPanel, PausePanel;
    public int lives, score, brickcountr, unlockLevel;
    public Text scoreText, FinalLevelScoreText, WinScoreText, addingLifeText;
    public bool gameOver, win;
    public AudioSource loserSound1, loserSound2, winnerSound1, winnerSound2, loseHeartSound, powerUpSound;

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
        scoreText.text = "Score: " + score;
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
        AddaLifePowerUp();

    }

    public void AddaLifePowerUp()
    {
        if (hearts.Length - 1 < lives)
        {
            powerUpSound.Play();
            addingLifeText.text = "+1";
        }
        else
        {
            loseHeartSound.Play();
            addingLifeText.text = " ";
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
        PlayerPrefs.SetInt("SavedInteger", (score * lives) + PlayerPrefs.GetInt("SavedInteger"));
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

    public void levelthree()
    {
        SceneManager.LoadScene("levelthree");
    }
}