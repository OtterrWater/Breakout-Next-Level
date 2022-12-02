using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    public Text LevelsCompletedText;
    void Start()
    {
        LevelsCompletedText.text = "Levels Completed: 00000";
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void goHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
