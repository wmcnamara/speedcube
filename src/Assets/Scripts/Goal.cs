using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Goal : MonoBehaviour
{
    //Level number. Used to load the next level after completion.
    public int levelIndex;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("LVL" + ++levelIndex);
    }
}
