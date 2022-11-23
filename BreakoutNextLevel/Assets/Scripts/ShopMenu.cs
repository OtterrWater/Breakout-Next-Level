using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public Text moneyCntrText;
    void Start()
    {
        moneyCntrText.text = "$00000";
    }
    
    public void shoptomain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}