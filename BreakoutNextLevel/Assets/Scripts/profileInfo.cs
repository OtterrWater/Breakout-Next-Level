using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class profileInfo : MonoBehaviour
{
    public Text ProfileNameText;
    public Text CoinText;
    public Text LevelsCompletedText;
    public Text SkinText;
    void Start()
    {
        ProfileNameText.text = "John Doe";
        CoinText.text = "Coins: $00000";
        LevelsCompletedText.text = "Levels Completed: 00000";
        SkinText.text = "Number of Skins: 00000";
    }
    public void goHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
