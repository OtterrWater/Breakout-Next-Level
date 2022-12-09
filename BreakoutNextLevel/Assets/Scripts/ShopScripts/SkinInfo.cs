using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "New Skin", menuName = "Create New Skin")]
public class SkinInfo : ScriptableObject
{
    public enum SkinIDs { Default, Baguette, GlassBottle, Holiday, HolidayTree, MintStick, SpaceShip }
    [SerializeField] private SkinIDs skinID;
    public SkinIDs _skinID { get { return skinID; } }

    [SerializeField] private Sprite skinSprite;
    public Sprite _skinSprite { get { return skinSprite; } }

    [SerializeField] private int skinPrice;
    public int _skinPrice { get { return skinPrice; } }
}
