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

    //Score variable.
    private float score;

    //Game is over.
    private bool endGame;
    // Update is called once per frame
    void Update()
    {
        //Increment score. +1 score a second.
        score += 1 * Time.deltaTime;

        //Cast the float to make reading the score easier.
        scoreText.text = "SCORE: " + (int)score;

        //Reset spawn and map when distance gets too large.
        if (GameObject.FindGameObjectWithTag("Player").transform.position.z < -10000)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, 0.5f, 0);
            GameObject.FindGameObjectWithTag("Map").transform.position = new Vector3(0, 0, 0);
        }

        //Allows the player to press space to restart.
        if (Input.GetKeyDown(KeyCode.Space) && endGame)
        {
            GameObject.Find("MenuGUIFunctions").GetComponent<MenuGUIFunctions>().ReloadThisLevel();
        }
    }

    private void Start()
    {
        //If they restart the game, it should set this to false.
        endGame = false;
    }
    
    //Ran from OnTriggerEnter() from any obstacle colliding with the Player.
    public void EndGame()
    {
        //Turn on the UI and remove the scoretext in the top left corner.
        endGamePanel.SetActive(true);
        scoreText.gameObject.SetActive(false);
        endGameScoreText.text = "FINAL SCORE: " + (int)score;

        //Stops player movement but allows GUI and key input.
        Time.timeScale = 0;
        
        //Allows after game input checking.
        endGame = true;
    }
}
