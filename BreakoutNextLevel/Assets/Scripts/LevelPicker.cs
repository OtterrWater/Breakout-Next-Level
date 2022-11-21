using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPicker : MonoBehaviour
{
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
}
