using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartMenu : MonoBehaviour
{
    public GameObject cogPanel;
    AsyncOperation loadingOperation;
    public GameObject userNamePanel;
    public TMP_InputField userInput;
    public Button submitButton;

    public static bool CogOn = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CogOn)
            {
                cogPanel.SetActive(false);
                Time.timeScale = 1f;
                CogOn = false;
            }
            else
            {
                cogPanel.SetActive(true);
                Time.timeScale = 0f;
                CogOn = true;
            }
        }
    }
    public void getInputOnClickHandler()
    {
        Debug.Log("Your username is: " + userInput.text);
    }
    public void CreateUsername()
    {
        PlayerPrefs.SetString("SavedUsername", userInput.text);
        Debug.Log("Profile Created! Welcome " + userInput.text);
    }
    public void LoadCreatePanel()
    {
        if (PlayerPrefs.GetString("SavedUsername") != "")
        {
            userNamePanel.SetActive(false);
        }
        else
            {
            userNamePanel.SetActive(true);
        }
    }
    void Awake()
    {
        LoadCreatePanel();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("shop");
        loadingOperation = SceneManager.LoadSceneAsync("LevelPicker");
    }

    public void OpenProfile()
    {
        SceneManager.LoadScene("ProfileInfo");
    }

    public void OpenShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Leaderboard()
    {
        SceneManager.LoadScene("Scores");
    }

    //all below: within CogPanel
    public void openCog()
    {
        if (cogPanel != null)
        {
            if (CogOn)
            {
                cogPanel.SetActive(false);
                Time.timeScale = 1f;
                CogOn = false;
            }
            else
            {
                cogPanel.SetActive(true);
                Time.timeScale = 0f;
                CogOn = true;
            }
        }
    }

    public void QuitGame()
    {
        PlayerPrefs.Save();
        Application.Quit();
        Debug.Log ("Button Quit activated");
    }

}
