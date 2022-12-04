using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinLoader : MonoBehaviour
{
    public SpriteRenderer playerSR;

    private void Awake()
    {
        playerSR.sprite = ShopMenu.equippedSkin;
    }
}
