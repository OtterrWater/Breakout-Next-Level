using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "New Skin", menuName = "Create New Skin")]
public class SkinInfo : ScriptableObject
{
    public enum SkinIDs { Default, Bottle, Rod, SpaceShip, Holiday }
    public SkinIDs skinID;
    public Sprite skinSprite;
    public int skinPrice;
}
