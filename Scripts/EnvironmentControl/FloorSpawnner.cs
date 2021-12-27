using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawnner : MonoBehaviour
{
    // build frame = 10 * compiler frame
    private float spawnRate = 5.0f;
    private float spawnTrigger = 0.0f;
    private float deleteRate = 25.0f;
    private float deleteTrigger = 0f;

    private float spawnZ = 0.0f;
    private float spawnX = 0.0f;
    private float pathLenth = 6f;
    private float turnPathLength = 7.5f;
    private int directionCount;
    //private string[] direction = new string[4] {"forward", "right", "left"};

    public static bool canDelete = false;
    public static bool justTurn = false;
    public bool canSpawnWallHole = false; //以防非人類行為的構造出現
    public Transform[] pathPrefabs;
    public Transform[] obstacle; //0:obstacle(wall), 1:coin

    private List<Transform> activePaths;
    private List<Transform> activeCoin;

    // Start is called before the first frame update
    void Start()
    {
        directionCount = 0;
        activePaths = new List<Transform>();
        activeCoin = new List<Transform>();

        for (int i = 0 ; i < 10; i++)
        {
            SpawnPath(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnTrigger++;
        if (spawnTrigger > spawnRate)
        {
            RandomPathGenerator();
            spawnTrigger = 0;
        }

        if (canDelete == true)
        {
            deleteTrigger++;
            if(deleteTrigger > deleteRate)
            {
                DeletePath();
                canDelete = false;
                deleteTrigger = 0;
            }
        }
    }
    
    void SpawnPath(int index)
    {
        Transform go, p;

        if(index == 1)//right
        {
            if (directionCount == 0)
            {
                go = Instantiate(pathPrefabs[0].transform);
                p = transform.GetChild(Random.Range(0, transform.childCount));
                go.parent = p;

                spawnX += 0.5f;
                spawnZ += turnPathLength;
                go.localPosition = Vector3.forward * spawnZ + Vector3.right * spawnX;

                directionCount++;
                activePaths.Add(go);
                justTurn = true;
                canSpawnWallHole = true;
            }
            else if (directionCount == 2)
            {
                go = Instantiate(pathPrefabs[3].transform);
                p = transform.GetChild(Random.Range(0, transform.childCount));
                go.parent = p;

                spawnX -= turnPathLength;
                spawnZ += 0.5f;
                go.localPosition = Vector3.forward * spawnZ + Vector3.right * spawnX;

                directionCount = 0;
                activePaths.Add(go);
                justTurn = true;
                canSpawnWallHole = true;
            }
        }
        else if(index == 2)//left
        {
            if (directionCount == 0)
            {
                go = Instantiate(pathPrefabs[1].transform);
                p = transform.GetChild(Random.Range(0, transform.childCount));
                go.parent = p;

                spawnX -= 0.5f;
                spawnZ += turnPathLength;
                go.localPosition = Vector3.forward * spawnZ + Vector3.right * spawnX;

                directionCount = 2;
                activePaths.Add(go);
                justTurn = true;
                canSpawnWallHole = true;
            }
            else if (directionCount == 1)
            {
                go = Instantiate(pathPrefabs[2].transform);
                p = transform.GetChild(Random.Range(0, transform.childCount));
                go.parent = p;

                spawnX += turnPathLength;
                spawnZ += 0.5f;
                go.localPosition = Vector3.forward * spawnZ + Vector3.right * spawnX;

                directionCount = 0;
                activePaths.Add(go);
                justTurn = true;
                canSpawnWallHole = true;
            }
        }
        else if ((index == 3) && canSpawnWallHole) //a hole
        {
            if (directionCount == 0)
            {
                spawnZ += pathLenth;
            }
            else if (directionCount == 1)
            {
                spawnX += pathLenth;
            }
            else if (directionCount == 2)
            {
                spawnX -= pathLenth;
            }

            canSpawnWallHole = false;
        }
        else
        {
            if (directionCount == 0)
            {
                go = Instantiate(pathPrefabs[4].transform);
                p = transform.GetChild(Random.Range(0, transform.childCount));
                go.parent = p;

                spawnZ += pathLenth;
                go.localPosition = Vector3.forward * spawnZ + Vector3.right * spawnX;
                activePaths.Add(go);
            }
            else if (directionCount == 1)
            {
                go = Instantiate(pathPrefabs[5].transform);
                p = transform.GetChild(Random.Range(0, transform.childCount));
                go.parent = p;

                spawnX += pathLenth;
                go.localPosition = Vector3.forward * spawnZ + Vector3.right * spawnX;
                activePaths.Add(go);
            }
            else if (directionCount == 2)
            {
                go = Instantiate(pathPrefabs[5].transform);
                p = transform.GetChild(Random.Range(0, transform.childCount));
                go.parent = p;

                spawnX -= pathLenth;
                go.localPosition = Vector3.forward * spawnZ + Vector3.right * spawnX;
                activePaths.Add(go);
            }

            RandomObjectGenerator();
        }
    }
    
    void DeletePath()
    {
        Destroy(activePaths[0].gameObject);
        activePaths.RemoveAt(0);
    }
    
    void RandomPathGenerator()
    {
        int randomPath;

        if (justTurn)
        {
            randomPath = 0;
            justTurn = false;
        }
        else
        {
            randomPath = Random.Range(0, 4);
        }

        SpawnPath(randomPath);
    }

    //determine if the obstacle or cion should be on the path
    void RandomObjectGenerator()
    {
        //generate obstacle:20% ; generate coin:40%
        int generate = Random.Range(0, 8);

        Transform o, p;

        if((generate == 0) && canSpawnWallHole) //wall
        {
            
            if(directionCount > 0)
            {
                o = Instantiate(obstacle[1].transform);
                p = transform.GetChild(Random.Range(0, transform.childCount));
                o.parent = p;
            }
            else
            {
                o = Instantiate(obstacle[0].transform);
                p = transform.GetChild(Random.Range(0, transform.childCount));
                o.parent = p;
            }

            o.localPosition = Vector3.forward * spawnZ + Vector3.right * spawnX;
            activePaths.Add(o);
            canSpawnWallHole = false;
        }
        else if((generate > 0) && (generate < 3)) //coin
        {
            o = Instantiate(obstacle[2].transform);
            p = transform.GetChild(Random.Range(0, transform.childCount));
            o.parent = p;

            o.localPosition = Vector3.forward * spawnZ + Vector3.right * spawnX + Vector3.up * 2;
            activeCoin.Add(o);
            canSpawnWallHole = true;
        }
    }
}
