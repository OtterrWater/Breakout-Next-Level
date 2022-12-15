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
    public Text SkinText;
    void Start()
    {
        LoadGame();
        ProfileNameText.text = PlayerPrefs.GetString("SavedUsername");
        CoinText.text = "Coins: "+ PlayerPrefs.GetInt("SavedCoins");
    }

    void Update()
    {
        LoadGameData();
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
