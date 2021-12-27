using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "viking")
        {
            Debug.Log("collision");
            Destroy(this.gameObject);
            ScoreHandler.coins += 1;
        }
    }
}

