using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    //TODO Implement this class in an "infinite" mode.
    public GameObject _obstacle;
    public GameObject plane;

    //reference to player object. Polls position and view data.
    [SerializeField]
    private Player player;

    //Lane objects
    public Transform right;
    public Transform middle;
    public Transform left;

    //Distance to spawn lanes
    public float spawnDistance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //Test code for CreateLane.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 pos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - spawnDistance);
            CreateLane(pos);
        }
    }

    //Create lane and return the object.
    GameObject CreateLane(Vector3 pos)
    {
        //Create parent object to return.
        GameObject parent = new GameObject("Lane");

        //Position indexes for spawning.
        int pos1Range = Random.Range(-1, 1);
        int pos2Range = Random.Range(-1, 1);
        if (pos1Range != pos2Range)
        {
            //Create the objects.
            GameObject obstacle1 = SpawnWithIndex(pos1Range, pos);
            GameObject obstacle2 = SpawnWithIndex(pos2Range, pos);

            //Set the parents to the lane object.
            obstacle1.transform.SetParent(parent.transform);
            obstacle2.transform.SetParent(parent.transform);
        }
        else   //If the objects are the same index only spawn one to reinforce randomness.
        {
            //Create object.
            GameObject obstacle1 = SpawnWithIndex(pos1Range, pos);

            //Set the parent to the lane object.
            obstacle1.transform.SetParent(parent.transform);
        }

        //Return the completed lane and finish.
        Debug.Log("Lane Created");
        return parent;
    }

    //Spawns object with lane index.
    //returns spawned object.
    public GameObject SpawnWithIndex(int index, Vector3 pos)
    {
        //Right
        if (index == 1) { GameObject obstacle = Instantiate(_obstacle, new Vector3(right.transform.position.x, 
            pos.y + 0.5f,
            pos.z), Quaternion.identity); return obstacle;
        }

        //Left
        if (index == -1) { GameObject obstacle = Instantiate(_obstacle, new Vector3(left.transform.position.x,
            pos.y + 0.5f,
            pos.z), Quaternion.identity); return obstacle;
        }

        //Middle
        if (index == 0) { GameObject obstacle = Instantiate(_obstacle, new Vector3(middle.transform.position.x,
            pos.y + 0.5f,
            pos.z), Quaternion.identity); return obstacle;
        }

        return null;
    }
}
