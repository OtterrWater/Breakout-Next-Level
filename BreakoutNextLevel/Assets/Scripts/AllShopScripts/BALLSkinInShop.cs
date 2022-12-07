using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BALLSkinInShop : MonoBehaviour
{
    [SerializeField] private BALLSkinInfo BALLskinInfo;
    public BALLSkinInfo _BALLskinInfo { get { return BALLskinInfo; } }

    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private Image skinImage;
    [SerializeField] private bool isBALLSkinUnlocked, isBALLFreeSkin;


    public void Awake()
    {
        skinImage.sprite = BALLskinInfo._BALLskinSprite;
        if (isBALLFreeSkin)
        {
            //buy
            if (ShopMenu.Instance.SpendingCoins(0))
            {
                PlayerPrefs.SetInt(BALLskinInfo._BALLskinID.ToString(), 1);
            }
        }
        IsBALLSkinUnlocked();
    }

    public void IsBALLSkinUnlocked()
    {
        if (PlayerPrefs.GetInt(BALLskinInfo._BALLskinID.ToString()) == 1)
        {
            isBALLSkinUnlocked = true;
            buttonText.text = "Equip";
        }
        else
        {
            buttonText.text = ("Buy: $" + BALLskinInfo._BALLskinPrice);
        } 
    }

    public void OnButtonPress()
    {
        if (isBALLSkinUnlocked)
        {
            //equip
            BALLSkinManager.Instance.BALLEquipSkin(this);
        }
        else
        {
            //buy
            if (ShopMenu.Instance.SpendingCoins(BALLskinInfo._BALLskinPrice))
            {
                PlayerPrefs.SetInt(BALLskinInfo._BALLskinID.ToString(), 1);
                IsBALLSkinUnlocked();
            }
        }
    }
}