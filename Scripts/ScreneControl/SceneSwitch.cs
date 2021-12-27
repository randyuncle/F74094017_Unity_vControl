using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour, IPointerClickHandler
{
    public int SceneIndexDestination;

    public void OnPointerClick(PointerEventData eventData)
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("current scene name = " + scene.name + " and scene index = " + scene.buildIndex);

        ReturnButtonController.isDead = false;
        ScoreHandler.coins = 0;
        ScoreHandler.duringTime = 0;

        SceneManager.LoadScene(SceneIndexDestination);
    }
}
