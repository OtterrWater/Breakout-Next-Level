using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class profileInfo : MonoBehaviour
{
    public Text CoinText;
    public Text LevelsCompletedText;
    public Text SkinText;
    public void goHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
