using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickScript : MonoBehaviour
{
    public int hitsToBreak;
    public Sprite hitSprite;

    public void BrickBroke()
    {
        hitsToBreak--;
        GetComponent<SpriteRenderer>().sprite = hitSprite;
    }
}
