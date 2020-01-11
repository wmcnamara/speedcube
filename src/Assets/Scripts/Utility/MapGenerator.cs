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

    public Transform midCheckLeft;
    public Transform midCheckRight;

    //Distance to spawn lanes
    public float spawnDistance;

    //Spawn a lane every second.
    public float spawnRate = 1f;

    //Assures the coroutine isnt ran every frame.
    public bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        //Make sure it runs properly.
        canSpawn = true;

        //Grab player data
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //Spawn the lanes
        if (canSpawn)
        {
            StartCoroutine("Spawn");
        }

        //Move the player forward.
        plane.transform.Translate(transform.forward * -player.movementSpeed * Time.deltaTime);
    }

    //Create lane and return the object.
    GameObject CreateLane(Vector3 pos)
    {
        //Create parent object and add a lane script. The function returns this object.,
        GameObject parent = new GameObject("Lane");
        parent.AddComponent<Lane>();

        //Position indices for spawning.
        int pos1Range = Random.Range(-1, 2);
        int pos2Range = Random.Range(-1, 2);
        int midCheckRange = Random.Range(0, 2);

        if (pos1Range != pos2Range)
        {
            //Create the objects.
            GameObject obstacle1 = SpawnWithIndex(pos1Range, pos);
            GameObject obstacle2 = SpawnWithIndex(pos2Range, pos);

            //Set the parents to the lane object.
            obstacle1.transform.SetParent(parent.transform);
            obstacle2.transform.SetParent(parent.transform);

            //Midchecks are needed to prevent players from spamming left and right to dodge objects.
            GameObject midCheck1;
            //Spawn midChecks if at left
            if (midCheckRange == 0)
            {
                midCheck1 = Instantiate(_obstacle, new Vector3(midCheckLeft.transform.position.x,
                                       pos.y + 0.5f,
                                       pos.z), Quaternion.identity);
            }

            //Spawn midChecks if at right
            if (midCheckRange == 1)
            {
                midCheck1 = Instantiate(_obstacle, new Vector3(midCheckRight.transform.position.x,
                                        pos.y + 0.5f,
                                        pos.z), Quaternion.identity);
            }

        }
        else   //If the objects are the same index only spawn one to reinforce randomness.
        {
            //Create object.
            GameObject obstacle1 = SpawnWithIndex(pos1Range, pos);

            //Set the parent to the lane object.
            obstacle1.transform.SetParent(parent.transform);
        }

        //Return the completed lane and finish.
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

    IEnumerator Spawn()
    {
        //Stop coroutine from running twice.
        canSpawn = false;

        //Make a lane and place it.
        CreateLane(new Vector3(player.transform.position.x, 
            player.transform.position.y, 
            player.transform.position.z - spawnDistance));

        //Wait for the spawnrate, and then allow the coroutine to run again.
        yield return new WaitForSeconds(spawnRate);
        canSpawn = true;
    }
}
