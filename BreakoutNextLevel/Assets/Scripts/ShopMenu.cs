using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public static Sprite equippedSkin;
    public Text moneyCntrText;
    public int coins;
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

    //using coins(purchasing)
    public bool SpendingCoins(int moneySpent)
    {
        //PLEASE HELP ME LOL(delete me comments after fixs please :3)
        //me guessing how to add coins
        //thankyou, ur awesome :3
        coins = PlayerPrefs.GetInt("SavedInteger");
        if (coins >= moneySpent)
        {
            coins -= moneySpent;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void EquipSkin(SkinInfo skinInfo)
    {
        equippedSkin = skinInfo.skinSprite;
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