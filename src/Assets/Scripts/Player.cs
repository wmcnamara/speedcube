using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Stops all input if true.
    public bool blockInput;

    //Stops all forward movement if true.
    public bool blockMovement;

    //Movement positions for players.
    public Transform right;
    public Transform middle;
    public Transform left;

    //A number indicating player position. -1 Left. 0 Middle. 1 Right.
    public int positionIndex;

    public float movementSpeed = 35;

    //Used by smoothdamp.
    public float smoothSpeed = 0.1f;
    //Value used exclusively by smoothdamp.
    private Vector3 velocity = Vector3.zero;


    //Cheat code vars
    public Material indpMat;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!blockMovement)
        {
            //Move the player forward.
            transform.Translate(transform.forward * -movementSpeed * Time.deltaTime);
        }

        //Control right movement.
        if (Input.GetButtonDown("Right") && !blockInput)
        {
            positionIndex++;
        }
        //Control left movement.
        if (Input.GetButtonDown("Left") && !blockInput)
        {
            positionIndex--;
        }

        //Reset position index if it is out of bounds.
        if (positionIndex > 1)
        {
            positionIndex = 1;
        }

        if (positionIndex < -1)
        {
            positionIndex = -1;
        }

        //Set player x position based on index.

        //Left
        if (positionIndex == -1) { transform.position = Vector3.SmoothDamp(transform.position, 
            new Vector3(left.position.x, transform.position.y, transform.position.z), ref velocity, smoothSpeed); }
        //Right
        if (positionIndex == 1) { transform.position = Vector3.SmoothDamp(transform.position,
            new Vector3(right.position.x, transform.position.y, transform.position.z), ref velocity, smoothSpeed);
        }
        //Middle
        if (positionIndex == 0) { transform.position = Vector3.SmoothDamp(transform.position,
            new Vector3(middle.position.x, transform.position.y, transform.position.z), ref velocity, smoothSpeed);
        }

        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("MainMenu");
        }

        //CHEAT CODES//
        //INDP skin cheat.
        if (GameObject.FindGameObjectWithTag("CheatCodeManager").GetComponent<CheatCodes>().indpSkinActive)
        {
            GetComponent<Renderer>().material = indpMat;
        }
    }

}