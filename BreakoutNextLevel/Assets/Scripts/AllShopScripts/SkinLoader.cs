using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinLoader : MonoBehaviour
{
    public SpriteRenderer Paddle;

    private void Awake()
    {
        Paddle.sprite = SkinManager.equippedSkin;
    }
}
