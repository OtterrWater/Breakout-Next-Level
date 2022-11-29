using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class profileInfo : GameManager
{
    public Text CoinText;
    public Text LevelsCompletedText;
    public Text SkinText;

    GameManager gameData = new GameManager();
  
    
    public void goHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public string displayCoins()
    {
        gameData.LoadGame();
        return CoinText.text = coinsToSave.ToString();
    }

    
    // Update is called once per frame
    void Update()
    {

    }

}




/*
public class profileInfo : MonoBehaviour
{
    
   
     public profileInfo()
     {
         this.coinsToSave=coinsToSave;
         this.levelsCompletedToSave=levelsCompletedToSave;
         this.numberOfSkinsToSave=numberOfSkinsToSave;

     }
   
 
     // Start is called before the first frame update
     void Start()
     {

     }

     // Update is called once per frame
     void Update()
     {

     }

    
}
*/
