using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ReturnButtonController : MonoBehaviour, IPointerClickHandler
{
    public static bool isDead = false;
    public int SceneIndexDestination;

    void Start()
    {
        GetComponent<Button>().enabled = false;
        GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            GetComponent<Button>().enabled = true;
            GetComponent<Image>().enabled = true;
        }
        else
        {
            GetComponent<Button>().enabled = false;
            GetComponent<Image>().enabled = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("current scene name = " + scene.name + " and scene index = " + scene.buildIndex);

        SceneManager.LoadScene(SceneIndexDestination);
    }
}
