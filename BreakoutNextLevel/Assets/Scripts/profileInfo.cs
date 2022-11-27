using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

/*
public class profileInfo : MonoBehaviour
{
    public Text CoinText;
    public Text LevelsCompletedText;
    public Text SkinText;
    public void goHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
*/

[Serializable]
public class SaveData
{
    public int savedCoins;
    public int savedLevelsCompleted;
    public int savedNumberOfSkins;
}

public class profileInfo : MonoBehaviour
{
    int coinsToSave;
    int levelsCompletedToSave;
    int numberOfSkinsToSave;
    public profileInfo()
    {
        this.coinsToSave=coinsToSave;
        this.levelsCompletedToSave=levelsCompletedToSave;
        this.numberOfSkinsToSave=numberOfSkinsToSave;
    }
    void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
                     + "/MySaveData.dat");
        SaveData data = new SaveData();
        profileInfo.data.savedCoins = coinsToSave;
        profileInfo.data.savedLevelsCompleted = levelsCompletedToSave;
        profileInfo.data.savedNumberOfSkins = numberOfSkinsToSave;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }
    void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath
                       + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
                       File.Open(Application.persistentDataPath
                       + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            coinsToSave = data.savedCoins;
            levelsCompletedToSave = data.savedLevelsCompleted;
            numberOfSkinsToSave = data.savedNumberOfSkins;
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }

    void ResetData()
    {
        if (File.Exists(Application.persistentDataPath
                      + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath
                              + "/MySaveData.dat");
            coinsToSave = 0;
            levelsCompletedToSave = 0;
            numberOfSkinsToSave = 0;
            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }
    public void goHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    /*
     // Start is called before the first frame update
     void Start()
     {

     }

     // Update is called once per frame
     void Update()
     {

     }
    */
}
