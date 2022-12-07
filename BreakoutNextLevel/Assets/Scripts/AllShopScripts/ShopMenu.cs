using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public static ShopMenu Instance;
    [SerializeField] private int coins;
    private const string prefMoney = "prefMoney";
    //private const string BALLprefMoney = "BALLprefMoney";
    public Text moneyCntrText;
    public static Sprite equippedSkin;
    public static Sprite BALLequippedSkin;

    private void Awake()
    {
        Instance = this;
        coins = PlayerPrefs.GetInt(prefMoney);
    }

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

    //using coins(purchasing)
    public bool SpendingCoins(int moneySpent)
    {
        //PLEASE HELP ME LOL(delete me comments after fixs please :3)
        //thankyou, ur awesome :3
        if (coins >= moneySpent)
        {
            coins -= moneySpent;
            PlayerPrefs.SetInt(prefMoney, coins);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void shoptomain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void EquipSkin(SkinInfo skinInfo)
    {
        equippedSkin = skinInfo._skinSprite;
    }

    public void EquipSkin(BALLSkinInfo BALLskinInfo)
    {
        BALLequippedSkin = BALLskinInfo._BALLskinSprite;
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