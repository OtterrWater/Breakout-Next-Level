using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public Text moneyCntrText;

    //SHOP TRANSFER
    public static Sprite equippedSkin;
    public int coins =20;

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

    //SHOP TRANSFER
    //using coins(purchasing)
    public bool SpendingCoins(int moneySpent)
    {
        //PLEASE HELP ME LOL(delete me comments after fixs please :3)
        //thankyou, ur awesome :3
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

}