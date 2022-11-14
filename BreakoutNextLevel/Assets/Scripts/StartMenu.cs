using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject cogPanel;
    public GameObject aboutPanel;
    public GameObject howToPlayPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("LevelPicker");
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

    public void openAbout()
    {
        aboutPanel.SetActive(true);
    }

    public void openHowToPlay()
    {
        howToPlayPanel.SetActive(true);
    }

    public void backtoCog()
    {
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log ("Button Quit activated");
    }

}
