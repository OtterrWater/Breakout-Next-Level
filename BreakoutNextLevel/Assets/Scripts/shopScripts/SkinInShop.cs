using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinInShop : MonoBehaviour
{
    public SkinInfo skinInfo;
    public TextMeshProUGUI buttonText;
    public Image skinImage;
    public bool isSkinUnlocked;

    public void Awake()
    {
        skinImage.sprite = skinInfo.skinSprite;
        IsSkinUnlocked();
    }

    public void IsSkinUnlocked()
    {
        if (PlayerPrefs.GetInt(skinInfo.skinID.ToString()) == 1)
        {
            isSkinUnlocked = true;
            buttonText.text = "Equip";
        }
    }

    public void OnButtonPress()
    {
        if (isSkinUnlocked)
        {
            //equip
            FindObjectOfType<ShopMenu>().EquipSkin(skinInfo);
        }
        else
        {
            //buy
            if (FindObjectOfType<ShopMenu>().SpendingCoins(skinInfo.skinPrice))
            {
                PlayerPrefs.SetInt(skinInfo.skinID.ToString(), 1);
                IsSkinUnlocked();
            }
        }
    }
}
