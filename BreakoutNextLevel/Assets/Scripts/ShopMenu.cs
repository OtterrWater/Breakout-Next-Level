using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public Text moneyCntrText;
    void Start()
    {
        moneyCntrText.text = "Coins: " + PlayerPrefs.GetInt("SavedInteger");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void shoptomain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public string purchaseSkin(string skinName)
    {
        //buy skin
        //update skin counter
        return "";
    }
    public string purchasePower(string powerName)
    {
        return "";
    }

}