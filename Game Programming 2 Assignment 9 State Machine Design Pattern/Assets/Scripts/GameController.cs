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
    public HealthStateManager healthStateManager;


    [Header("Tutorial Stuff")]
    public GameObject tutorialPanel;
    public float timerDuration;
    public Text tutorialTimerText;
    private bool skipTutorial;

    public GameObject gamePanel;
    public GameObject gameOverPanel;

    public Slider healthBar;
    public int maxHealthValue = 100;
    public Text healthText;

    [Range(0, 100)]
    public int infectionPercentage;
    public Text infectionText;

    public Text descriptionText;

    public int newInfectionPercentage;
    public int newHealthNum;

    // Start is called before the first frame update
    void Start()
    {
        skipTutorial = false;
        tutorialPanel.SetActive(true);
        StartCoroutine(TutorialTimer());

        Debug.Log("This is the state of the health: " + healthStateManager.currentState);
        healthStateManager.currentState.FullHealth();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Skip Tutorial: " + skipTutorial);
        descriptionText.text = "Whatever it needs to say";
        infectionText.text = "Infection: %" + infectionPercentage;
        healthText.text = "Health: %" + healthBar.value.ToString("0");
    }

    // Button that skipps the tutorial
    public void SkipTutoial()
    {
        skipTutorial = true;
    }

    // Button that lowers infection rate
    public int Disinfect()
    {
        if (infectionPercentage <= 0)
        {
            descriptionText.text = "You're infection rate is actually zero! That's good!";
        }
        else if (infectionPercentage > 0)
        {
            newInfectionPercentage = infectionPercentage - 25;
        }

        return newInfectionPercentage;
    }

    public int GoShop()
    {
        newInfectionPercentage = infectionPercentage + 25;

        return newInfectionPercentage;
    }


    // Timer for the tutorial
    public IEnumerator TutorialTimer()
    {
        timerDuration = 5f;

        while(timerDuration > 0 && skipTutorial == false)
        {
            timerDuration -= Time.deltaTime;
            tutorialTimerText.text = "Tutorial Timer: " + timerDuration.ToString("00");
            yield return null;
        }

        if(timerDuration <= 0 || skipTutorial == true)
        {
            tutorialPanel.SetActive(false);
            StopAllCoroutines();
        }
    }

    public IEnumerator GameOver()
    {
        if(healthBar.value <= 0)
        {
            healthStateManager.currentState.NoHealth();

            yield return new WaitForSeconds(5f);

            tutorialPanel.SetActive(false);
            gamePanel.SetActive(false);
            gameOverPanel.SetActive(true);
        }
    }
}
