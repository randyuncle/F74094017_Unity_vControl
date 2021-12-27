using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.transform.name == "viking"))
        {
            FloorSpawnner.canSpawn = true;
        }
    }
    */
    private void OnCollisionExit(Collision collision)
    {
        if((collision.transform.name == "viking"))
        {
            FloorSpawnner.canDelete = true;
        }
    }
}
