using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public static Sprite equippedSkin;
    public SkinInfo[] allSkins;

    private void Awake()
    {
        //SKIN DOES NOT AUTOMATICALLY SPAWN DEFAULT SKIN
        string mostRecentSkin = PlayerPrefs.GetString("skinPref", SkinInfo.SkinIDs.Default.ToString());
        foreach (SkinInfo skin in allSkins)
        {
            if (skin.skinID.ToString() == mostRecentSkin)
            {
                EquipSkin(skin);
            }
        }
    }

    public void EquipSkin(SkinInfo skinInfo)
    {
        equippedSkin = skinInfo.skinSprite;
        PlayerPrefs.SetString("skinPref", skinInfo.skinID.ToString());
    }
}
