using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Endzone : MonoBehaviour
{
    //Level number. Used to load the next level after completion.
    public int levelIndex;

    private void OnTriggerEnter(Collider other)
    {
        //If the next scene is not null, go to it.
        if (Application.CanStreamedLevelBeLoaded("LVL" + ++levelIndex))
        {
            SceneManager.LoadScene("LVL" + ++levelIndex);
        }
        else
        {
            SceneManager.LoadScene("EndGame");
        }
    }
}
