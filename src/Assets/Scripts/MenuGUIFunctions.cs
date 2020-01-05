using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuGUIFunctions : MonoBehaviour
{
    //Sets the level to LVL1. Begins the game.
    public void StartGame()
    {
        SceneManager.LoadScene("LVL1");
    }

    //Quits game
    public void Exit()
    {
        Application.Quit();
    }

    //Opens my github.
    public void OpenGithub()
    {
        Application.OpenURL("https://github.com/westonmcnamara");
    }
}
