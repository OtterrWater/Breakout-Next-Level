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
    //public TMP_InputField userInput;
    //public Button submitButton;
   // public GameObject userNamePanel;

    void Awake()
    {
        LoadGame();
    }
    /*
    public void getInputOnClickHandler()
    {
        Debug.Log("Your username is: " + userInput.text);
    }
    public void CreateUsername()
    {
        PlayerPrefs.SetString("SavedUsername", userInput.text);
        Debug.Log("Profile Created! Welcome " + userInput.text);
    }
    */

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
            //  Debug.Log("Game data loaded!");
            /*
            if (PlayerPrefs.GetString("SavedUsername") == usernameToSave)
            {
                userNamePanel.SetActive(false);
            }
            else ((PlayerPrefs.GetString("SavedUsername") == usernameToSave))
            {
                userNamePanel.SetActive(true);
            }
            */
        }
        //else
        //    userNamePanel.SetActive(true);
            //Debug.LogError("There is no save data!");
    }

    public void LoadGameData()
    {
        if (PlayerPrefs.HasKey("SavedInteger") || PlayerPrefs.HasKey("SavedSkins") || PlayerPrefs.HasKey("SavedLevels") || PlayerPrefs.HasKey("SavedUsername"))
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
