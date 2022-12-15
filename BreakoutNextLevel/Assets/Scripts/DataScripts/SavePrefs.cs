using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SavePrefs : MonoBehaviour
{
    
    public int coinsToSave;
    public int skinsToSave;
    public int levelsToSave;
    public string usernameToSave;

    void Awake()
    {
        LoadGame();
    }

    public void SaveGame()
    {
        PlayerPrefs.SetString("SavedUsername", PlayerPrefs.GetString("SavedUsername")); 
        PlayerPrefs.SetInt("SavedCoins", coinsToSave);
        PlayerPrefs.SetInt("SavedSkins", skinsToSave);
        PlayerPrefs.SetInt("SavedLevels", levelsToSave);
        PlayerPrefs.Save();
       // Debug.Log("Game data saved!");
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedInteger")|| PlayerPrefs.HasKey("SavedSkins") || PlayerPrefs.HasKey("SavedLevels") ||PlayerPrefs.HasKey("SavedUsername"))
        {
            usernameToSave = PlayerPrefs.GetString("SavedUsername");
            coinsToSave = PlayerPrefs.GetInt("SavedCoins");
            skinsToSave = PlayerPrefs.GetInt("SavedSkins");
            levelsToSave = PlayerPrefs.GetInt("SavedLevels");
        }
    }
    
    public void ResetGame()
    {
        PlayerPrefs.SetString("SavedUsername", "");
        PlayerPrefs.SetInt("SavedCoins", 0);
        PlayerPrefs.SetInt("SavedSkins", 0);
        PlayerPrefs.SetInt("SavedLevels", 0);
        Application.Quit();
        Debug.Log("Profile Reset. Exiting...");
    }

}
