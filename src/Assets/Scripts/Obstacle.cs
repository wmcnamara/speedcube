using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

//Uses a timestamp method to destroy the object after player zooms by it.
public class Obstacle : MonoBehaviour
{
    public float deathTime = 5.0f;

    private float initTime;
    // Start is called before the first frame update
    void Start()
    {
        //Time since level loaded.
        initTime = Time.timeSinceLevelLoad;
    }

    private void Update()
    {
        //If the object has been around lounger than deathtime destroy it.
        if (Time.timeSinceLevelLoad - initTime > deathTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().EndGame();
            Debug.Log("Game Over");
        }
    }
}
