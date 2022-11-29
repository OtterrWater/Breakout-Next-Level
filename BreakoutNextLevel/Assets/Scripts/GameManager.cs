using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class SaveData
{
    public int savedCoins;
    public int savedLevelsCompleted;
    public int savedNumberOfSkins;
}
public class GameManager : MonoBehaviour
{
    public int coins;
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

    //data 
    public int coinsToSave;
    public int levelsCompletedToSave;
    public int numberOfSkinsToSave;


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
        coinsToSave = score * lives;
        SaveGame();
    }
    void OnGUI()
    {
        GUI.Label(new Rect(375, 200, 125, 50), "Current Coins "
                + coinsToSave);
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
    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
                 + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.savedCoins = coinsToSave;
        data.savedLevelsCompleted = levelsCompletedToSave;
        data.savedNumberOfSkins = numberOfSkinsToSave;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath
                       + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
                       File.Open(Application.persistentDataPath
                       + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            coinsToSave = data.savedCoins;
            levelsCompletedToSave = data.savedLevelsCompleted;
            numberOfSkinsToSave = data.savedNumberOfSkins;
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }

    public void ResetData()
    {
        if (File.Exists(Application.persistentDataPath
                      + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath
                              + "/MySaveData.dat");
            coinsToSave = 0;
            levelsCompletedToSave = 0;
            numberOfSkinsToSave = 0;
            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }
    public void goHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
}