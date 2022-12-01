using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePrefs : MonoBehaviour
{
    
    public int coinsToSave;
    public int skinsToSave;
    public int levelsToSave;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveGame()
    {
        PlayerPrefs.SetInt("SavedCoins", coinsToSave);
        PlayerPrefs.SetInt("SavedSkins", skinsToSave);
        PlayerPrefs.SetInt("SavedLevels", levelsToSave);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }
    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedInteger")|| PlayerPrefs.HasKey("SavedSkins") || PlayerPrefs.HasKey("SavedLevels"))
        {
            coinsToSave = PlayerPrefs.GetInt("SavedCoins");
            skinsToSave = PlayerPrefs.GetInt("SavedSkins");
            levelsToSave = PlayerPrefs.GetInt("SavedLevels");
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }

}
