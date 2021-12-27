using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public static int coins = 0;
    public static float duringTime = 0;

    private void Start()
    {
        duringTime = 0;
    }

    private void Update()
    {
        if (!ReturnButtonController.isDead)
        {
            duringTime += Time.deltaTime;
            this.GetComponent<Text>().enabled = true;
            this.GetComponent<Text>().text = "Coins:" + coins ;
        }
        else
        {
            this.GetComponent<Text>().enabled = false;
        }
    }
}
