using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class profileInfo : SavePrefs
{
    public Text ProfileNameText;
    public Text CoinText;
    public Text LevelsCompletedText;
    public Text SkinText;
    void Start()
    {
        LoadGame();
        ProfileNameText.text = "John Doe";
        CoinText.text = "Coins: "+ PlayerPrefs.GetInt("SavedInteger");
        LevelsCompletedText.text = "Levels Completed: 00000";
        SkinText.text = "Number of Skins: 00000";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void goHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
