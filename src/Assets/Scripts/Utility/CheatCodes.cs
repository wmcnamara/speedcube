using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCodes : MonoBehaviour
{
    //Materials to use when INDP cheat code is active.
    public Material[] indpMat;

    //Cheat codes reset after restart.
    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //If keys I N D P are pressed run INDPSkin() code.
        if (Input.GetKey(KeyCode.I) && Input.GetKey(KeyCode.N) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.P))
        {
            INDPSkin();
        }

        //If keys R U N 9 are pressed the RUN90 code.
        if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.U) && Input.GetKey(KeyCode.N) && Input.GetKey(KeyCode.Alpha9))
        {
            RUN90();
        }
    }

    //Variable to check if indp skin cheat is enabled.
    public bool indpSkinActive;

    //Add INDP skin to player.
    //The player checks if this is true and runs the response function.
    private void INDPSkin()
    {
        indpSkinActive = true;
    }

    //Variable to check if RUN90 cheat is enabled.
    public bool run90Enabled;

    //Run90 song
    public AudioSource run90song;

    //Double player movement speed.
    //The player checks if this is true and runs the response function.
    private void RUN90 ()
    {
        run90Enabled = true;
        run90song.Play();
    }
}
