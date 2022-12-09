using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "New Ball Skin", menuName = "Create New Ball Skin")]
public class BALLSkinInfo : ScriptableObject
{
    public enum BALLSkinIDs { BallDefault, Volleyball, SoccerBall, Ornament, BasketBall, MintCandy, SpaceBall }
    [SerializeField] private BALLSkinIDs BALLskinID;
    public BALLSkinIDs _BALLskinID { get { return BALLskinID; } }

    [SerializeField] private Sprite BALLskinSprite;
    public Sprite _BALLskinSprite { get { return BALLskinSprite; } }

    [SerializeField] private int BALLskinPrice;
    public int _BALLskinPrice { get { return BALLskinPrice; } }
}
