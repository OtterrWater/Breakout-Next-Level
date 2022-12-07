using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BALLSkinManager : MonoBehaviour
{
    public static BALLSkinManager Instance;
    public static Sprite BALLequippedSkin { get; private set; }
    [SerializeField] private BALLSkinInfo[] BALLallSkins;
    private const string BALLskinPref = "BALLskinPref";
    [SerializeField] private Transform BALLskinsInShopPanelsParent;
    [SerializeField] private List<BALLSkinInShop> BALLskinsInShopPanels = new List<BALLSkinInShop>();
    private Button usingThisSkinButton;

    private void Awake()
    {
        Instance = this;
        //SKIN DOES NOT AUTOMATICALLY SPAWN DEFAULT SKIN
        foreach (Transform s in BALLskinsInShopPanelsParent)
        {
            if(s.TryGetComponent(out BALLSkinInShop BALLskinInShop))
            {
                BALLskinsInShopPanels.Add(BALLskinInShop);
            }
        }
        BALLEquipPrevSkin();
        BALLSkinInShop BALLskinEquippedPanel = Array.Find(BALLskinsInShopPanels.ToArray(), dummyFind => dummyFind._BALLskinInfo._BALLskinSprite == BALLequippedSkin);
        usingThisSkinButton = BALLskinEquippedPanel.GetComponentInChildren<Button>();
        usingThisSkinButton.interactable = false;
    }

    
    private void BALLEquipPrevSkin()
    {
        string BALLTheMostRecentSkin = PlayerPrefs.GetString("BALLskinPref", BALLSkinInfo.BALLSkinIDs.BallDefault.ToString());
        BALLSkinInShop BALLskinEquippedPanel = Array.Find(BALLskinsInShopPanels.ToArray(), dummyFind => dummyFind._BALLskinInfo._BALLskinID.ToString() == BALLTheMostRecentSkin);
        BALLEquipSkin(BALLskinEquippedPanel);
    }
    

    public void BALLEquipSkin(BALLSkinInShop BALLskinInfoInShop)
    {
        BALLequippedSkin = BALLskinInfoInShop._BALLskinInfo._BALLskinSprite;
        PlayerPrefs.SetString(BALLskinPref, BALLskinInfoInShop._BALLskinInfo._BALLskinID.ToString());

        if (usingThisSkinButton != null)
        {
            usingThisSkinButton.interactable = true;
        }
        usingThisSkinButton = BALLskinInfoInShop.GetComponentInChildren<Button>();
        usingThisSkinButton.interactable = false;
    }
}