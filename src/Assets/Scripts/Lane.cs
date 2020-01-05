using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public float deathTime = 4.0f;

    private float initTime;

    // Start is called before the first frame update
    void Start()
    {
        //Time since level loaded.
        initTime = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        //If the object has been around lounger than deathtime destroy it.
        if (Time.timeSinceLevelLoad - initTime > deathTime)
        {
            Destroy(gameObject);
        }
    }
}
