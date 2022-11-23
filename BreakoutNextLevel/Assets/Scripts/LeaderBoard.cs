using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderBoard : MonoBehaviour
{
    public void goHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
