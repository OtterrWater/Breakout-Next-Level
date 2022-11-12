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
        SceneManager.LoadScene("firstgame");
    }

    public void openCog()
    {
        if (cogPanel != null)
        {
            bool isActive = cogPanel.activeSelf;
            cogPanel.SetActive(!isActive);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log ("Button Quit activated");
    }
}
