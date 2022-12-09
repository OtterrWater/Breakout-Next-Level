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
    public GameObject urbrokePanel;

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
            urbrokePanel.SetActive(false);
            coins -= moneySpent;
            PlayerPrefs.SetInt("SavedCoins", coins);
            moneyCntrText.text = "Coins: " + PlayerPrefs.GetInt("SavedCoins");
            Debug.Log(moneySpent + "coins spent");
            return true;
        }
        else
        {
            urbrokePanel.SetActive(true);
            Debug.Log("Not enough coins");
            return false;
        }
    }

    public void undestood()
    {
        urbrokePanel.SetActive(false);
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