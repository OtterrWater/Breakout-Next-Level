using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPicker : MonoBehaviour
{
    public Button[] levelButtons;
    void Start()
    {
        int currentLevel = PlayerPrefs.GetInt("currentStateAt", 5);
        for(int i = 1; i < levelButtons.Length; i++)
        {
            if (i + 5 > currentLevel)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void home()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void levelone()
    {
        SceneManager.LoadScene("levelone");
    }

    public void leveltwo()
    {
        SceneManager.LoadScene("leveltwo");
    }

    public void levelthree()
    {
        SceneManager.LoadScene("levelthree");
    }
}
