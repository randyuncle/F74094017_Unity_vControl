using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnTextShow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ReturnButtonController.isDead)
        {
            GetComponent<Text>().enabled = true;
        }
        else
        {
            GetComponent<Text>().enabled = false;
        }
    }
}
