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
    public TMP_InputField userInput;
    public Button submitButton;
    public GameObject userNamePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getInputOnClickHandler()
    {
        Debug.Log("Your username is: " + userInput.text);
    }
    public void CreateUsername()
    {
        PlayerPrefs.SetString("SavedUsername", userInput.text);
        Debug.Log("Profile Created! Welcome "+userInput.text);
    }
    public void CloseUserNamePanel()
    {
        userNamePanel.SetActive(false);
        Debug.Log("UserNamePanel Closed");
    }
    public void SaveGame()
    {
       
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
        }
        else
           Debug.LogError("There is no save data!");
    }

}
