using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Tracks score and other game data.
public class GameManager : MonoBehaviour
{
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
        scoreText.text = "Score: " + score.ToString();

        //Reset spawn and map when distance gets too large.
        if (GameObject.FindGameObjectWithTag("Player").transform.position.z < -10000)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, 0.5f, 0);
            GameObject.FindGameObjectWithTag("Map").transform.position = new Vector3(0, 0, 0);
        }
        if (Input.anyKeyDown && endGame)
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
        endGameScoreText.text = "Final Score: " + (int)score;
        Time.timeScale = 0;
        //If they press a key reload the scene.
        endGame = true;
    }
}
