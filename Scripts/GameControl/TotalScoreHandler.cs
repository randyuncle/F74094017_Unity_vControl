using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScoreHandler : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ReturnButtonController.isDead)
        {
            GetComponent<Text>().enabled = true;
            GetComponent<Text>().text = "You are dead !\r\nFinal score in this round: \r\n" + "Coins : " +ScoreHandler.coins + "\r\nServive time : " + ScoreHandler.duringTime + " (sec)";
        }
        else
        {
            GetComponent<Text>().enabled = false;
        }
    }
}
