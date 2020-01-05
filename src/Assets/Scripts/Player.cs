using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Stops all input if true.
    public bool blockInput;

    //Movement positions for players.
    public Transform right;
    public Transform middle;
    public Transform left;

    //A number indicating player position. -1 Left. 0 Middle. 1 Right.
    public int positionIndex;

    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move the player forward.
        transform.Translate(transform.forward * -movementSpeed * Time.deltaTime);

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
        if (positionIndex == -1) { transform.position = new Vector3(left.position.x, transform.position.y, transform.position.z); }
        //Right
        if (positionIndex == 1) { transform.position = new Vector3(right.position.x, transform.position.y, transform.position.z); }
        //Middle
        if (positionIndex == 0) { transform.position = new Vector3(middle.position.x, transform.position.y, transform.position.z); }

        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}