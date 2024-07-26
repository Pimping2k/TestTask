using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public void PressPlay()
    {
        Time.timeScale = 1f;
        PlayerPrefs.GetInt("Score");
        SceneManager.LoadScene(1);
    }

    public void PressExit()
    {
        Application.Quit();
    }

    public void PressNewGame()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(1);
    }
}
