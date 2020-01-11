using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCodes : MonoBehaviour
{
    //Cheat codes reset after restart.
    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        //If keys I N D P are pressed run INDPSkin() code.
        if (Input.GetKey(KeyCode.I) && Input.GetKey(KeyCode.N) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.P))
        {
            INDPSkin();
        } 
    }

    //Variable to check if indp skin cheat is enabled.
    public bool indpSkinActive;

    //Add INDP skin to player.
    //The player checks if this is true and runs the response function.
    private void INDPSkin ()
    {
        indpSkinActive = true;
    }
}
