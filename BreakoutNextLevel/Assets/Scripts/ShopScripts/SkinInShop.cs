using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinInShop : MonoBehaviour
{
    [SerializeField] private SkinInfo skinInfo;
    public SkinInfo _skinInfo { get { return skinInfo; } }

    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private Image skinImage;
    [SerializeField] private bool isSkinUnlocked, isFreeSkin;


    public void Awake()
    {
        skinImage.sprite = skinInfo._skinSprite;
        if (isFreeSkin)
        {
            //buy
            if (ShopMenu.Instance.SpendingCoins(0))
            {
                PlayerPrefs.SetInt(skinInfo._skinID.ToString(), 1);
            }
        }
        IsSkinUnlocked();
    }

    public void IsSkinUnlocked()
    {
        if (PlayerPrefs.GetInt(skinInfo._skinID.ToString()) == 1)
        {
            isSkinUnlocked = true;
            buttonText.text = "Equip";
        }
        else
        {
            buttonText.text = ("Buy: " + skinInfo._skinPrice);
        } 
    }

    public void OnButtonPress()
    {
        if (isSkinUnlocked)
        {
            //equip
            SkinManager.Instance.EquipSkin(this);
        }
        else
        {
            //buy
            if (ShopMenu.Instance.SpendingCoins(skinInfo._skinPrice))
            {
                PlayerPrefs.SetInt(skinInfo._skinID.ToString(), 1);
                IsSkinUnlocked();
            }
        }
    }
}