using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Tracks score and other game data.
public class GameManager : MonoBehaviour
{
    //UI elements
    public TextMeshProUGUI scoreText;
    public GameObject endGamePanel;
    public TextMeshProUGUI endGameScoreText;

    private float score;

    //Game is over.
    private bool endGame;
    // Update is called once per frame
    void Update()
    {
        score += 1 * Time.deltaTime;

        //Truncate the integer to make reading the score easier.
        scoreText.text = "Score: " + (int)score;

        //Reset spawn and map when distance gets too large.
        if (GameObject.FindGameObjectWithTag("Player").transform.position.z < -10000)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, 0.5f, 0);
            GameObject.FindGameObjectWithTag("Map").transform.position = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && endGame)
        {
            GameObject.Find("MenuGUIFunctions").GetComponent<MenuGUIFunctions>().ReloadThisLevel();
        }
    }

    private void Start()
    {
        endGame = false;
    }
    public void EndGame()
    {
        endGamePanel.SetActive(true);
        scoreText.gameObject.SetActive(false);
        endGameScoreText.text = "FINAL SCORE: " + (int)score;
        Time.timeScale = 0;
        //If they press a key reload the scene.
        endGame = true;
    }
}
