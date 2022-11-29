using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] hearts;
    public int lives;
    public int score;
    public Text scoreText;
    public Text FinalLevelScoreText;
    public Text WinScoreText;
    public bool gameOver;
    public bool win;
    public GameObject gameOverPanel;
    public GameObject WinnerPanel;
    public int brickcountr;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;

        brickcountr = GameObject.FindGameObjectsWithTag("brick").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        PlayerPrefs.SetInt("SavedInteger", (score * lives));
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