using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public static SkinManager Instance;
    public static Sprite equippedSkin { get; private set; }
    [SerializeField] private SkinInfo[] allSkins;
    private const string skinPref = "skinPref";
    [SerializeField] private Transform skinsInShopPanelsParent;
    [SerializeField] private List<SkinInShop> skinsInShopPanels = new List<SkinInShop>();
    private Button usingThisSkin;

    private void Awake()
    {
        Instance = this;
        //SKIN DOES NOT AUTOMATICALLY SPAWN DEFAULT SKIN
        foreach (Transform s in skinsInShopPanelsParent)
        {
            if(s.TryGetComponent(out SkinInShop skinInShop))
            {
                skinsInShopPanels.Add(skinInShop);
            }
            EquipPrevSkin();
            SkinInShop skinEquippedPanel = Array.Find(skinsInShopPanels.ToArray(), dummyFind => dummyFind._skinInfo._skinSprite == equippedSkin);
            usingThisSkin = skinEquippedPanel.GetComponentInChildren<Button>();
            usingThisSkin.interactable = false;
        }
    }

    private void EquipPrevSkin()
    {
        string TheMostRecentSkin = PlayerPrefs.GetString("skinPref", SkinInfo.SkinIDs.Default.ToString());
        SkinInShop skinEquippedPanel = Array.Find(skinsInShopPanels.ToArray(), dummyFind => dummyFind._skinInfo._skinID.ToString() == TheMostRecentSkin);
        EquipSkin(skinEquippedPanel);
    }

    public void EquipSkin(SkinInShop skinInfoInShop)
    {
        equippedSkin = skinInfoInShop._skinInfo._skinSprite;
        PlayerPrefs.SetString(skinPref, skinInfoInShop._skinInfo._skinID.ToString());

        if (usingThisSkin != null)
        {
            usingThisSkin.interactable = true;
        }
        usingThisSkin = skinInfoInShop.GetComponentInChildren<Button>();
        usingThisSkin.interactable = false;
    }
}
