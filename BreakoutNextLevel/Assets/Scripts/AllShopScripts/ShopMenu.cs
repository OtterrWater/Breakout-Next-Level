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
    public Text moneyCntrText;
    public static Sprite equippedSkin;
    public static Sprite BALLequippedSkin;

    private void Awake()
    {
        Instance = this;
        coins = PlayerPrefs.GetInt("SavedCoins");
    }

    void Start()
    {
        coins = PlayerPrefs.GetInt("SavedCoins");
        moneyCntrText.text = "Coins: " + PlayerPrefs.GetInt("SavedCoins");
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
        if (coins >= moneySpent)
        {
            coins -= moneySpent;
            PlayerPrefs.SetInt("SavedCoins", coins); 
            Debug.Log(moneySpent + "coins spent");
            return true;
        }
        else
        {
            Debug.Log("Not enough coins");
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

}