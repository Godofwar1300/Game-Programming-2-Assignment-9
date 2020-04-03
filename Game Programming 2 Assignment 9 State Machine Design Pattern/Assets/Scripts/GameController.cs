/*
* (Christopher Green)
* (GameController.cs)
* (Assignment 9)
* (This script handles the basic gameplay of the game.)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Tutorial Stuff")]
    public GameObject tutorialPanel;
    public float timerDuration;
    public Text tutorialTimerText;

    public GameObject gamePanel;

    // Start is called before the first frame update
    void Start()
    {
        gamePanel.SetActive(false);
        tutorialPanel.SetActive(true);
        StartCoroutine(TutorialTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator TutorialTimer()
    {
        timerDuration = 5f;

        while(timerDuration > 0)
        {
            timerDuration -= Time.deltaTime;
            tutorialTimerText.text = "Tutorial Timer: " + timerDuration.ToString("00");
            yield return null;
        }

        if(timerDuration <= 0)
        {
            tutorialPanel.SetActive(false);
            gamePanel.SetActive(true);
            StopAllCoroutines();
        }

    }

}
