using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject cogPanel;
    public void StartGame()
    {
        SceneManager.LoadScene("LevelPicker");
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
        SceneManager.LoadScene("LeaderBoard");
    }

    //all below: within CogPanel
    public void openCog()
    {
        if (cogPanel != null)
        {
            bool cogActive = cogPanel.activeSelf;
            cogPanel.SetActive(!cogActive);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log ("Button Quit activated");
    }

}
