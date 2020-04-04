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

    public int totalRollsOfToiletPaper;
    public Text toiletPaperStockText;

    public Text gameOverText;

    public Button stayAtHomeButton;
    public Button disinfectButton;
    public Button shopButton;
    bool stayHomeWasPressed;

    // Start is called before the first frame update
    void Start()
    {
        stayHomeWasPressed = false;
        skipTutorial = false;
        tutorialPanel.SetActive(true);
        StartCoroutine(TutorialTimer());
    }

    // Update is called once per frame
    void Update()
    {
        infectionText.text = "Infection: " + infectionPercentage + "%";
        healthText.text = "Health: " + healthBar.value.ToString("0") + "%";
        toiletPaperStockText.text = "Toilet Paper Stock: " + totalRollsOfToiletPaper + "/ 100";

        if(infectionPercentage >= 100)
        {
            StartCoroutine(GameOver());
            stayAtHomeButton.interactable = false;
            disinfectButton.interactable = false;
            shopButton.interactable = false;
        }
        else if(totalRollsOfToiletPaper >= 100)
        {
            StartCoroutine(GameOver());
            stayAtHomeButton.interactable = false;
            disinfectButton.interactable = false;
            shopButton.interactable = false;
        }
        
        
        if (healthBar.value == healthBar.maxValue)
        {
            healthStateManager.currentState.FullHealth();
        }
        else if (healthBar.value <= 75 && healthBar.value >= 25)
        {
            healthStateManager.currentState.HalfHealth();
        }
        else if (healthBar.value == 0)
        {
            stayAtHomeButton.interactable = false;
            disinfectButton.interactable = false;
            shopButton.interactable = false;
            StartCoroutine(GameOver());
            healthStateManager.currentState.NoHealth();
        }
    }

    // Button that skipps the tutorial
    public void SkipTutoial()
    {
        skipTutorial = true;
    }

    // Button that lowers infection rate
    public void Disinfect()
    {
        
        if (infectionPercentage > 0)
        {
            infectionPercentage -= 25;
            healthBar.value += Random.Range(0, 25);

            if(totalRollsOfToiletPaper > 0)
            {
                totalRollsOfToiletPaper -= Random.Range(1, 5);

                if(totalRollsOfToiletPaper < 0)
                {
                    totalRollsOfToiletPaper = 0;
                }
            }


        }
    }

    public void GoShop()
    {
        infectionPercentage += 25;
        healthBar.value -= Random.Range(10, 25);
        totalRollsOfToiletPaper += 10;
    }

    public void StayHome()
    {
        if(stayHomeWasPressed == false)
        {
            infectionPercentage = 0;
            healthBar.value = healthBar.maxValue;
            stayAtHomeButton.interactable = false;
            disinfectButton.interactable = false;
            shopButton.interactable = false;
            StartCoroutine(GameOver());
        }
    }


    // Timer for the tutorial
    public IEnumerator TutorialTimer()
    {
        timerDuration = 15f;

        while (timerDuration > 0 && skipTutorial == false)
        {
            timerDuration -= Time.deltaTime;
            tutorialTimerText.text = "Tutorial Timer: " + timerDuration.ToString("00");
            yield return null;
        }

        if (timerDuration <= 0 || skipTutorial == true)
        {
            tutorialPanel.SetActive(false);
            StopAllCoroutines();
        }
    }

    public IEnumerator GameOver()
    {

        yield return new WaitForSeconds(3f);

        tutorialPanel.SetActive(false);
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);

        if(totalRollsOfToiletPaper >= 100)
        {
            gameOverText.text = "Policeman: Wow that is a lot of toilet paper...no wonder the house burnt down.\n\n *You obtained a true hoarders death*" ;
        }
        else if(infectionPercentage >= 100)
        {
            gameOverText.text = "You became another mortality statistic in the wake of this deadly disease...guess you should have bought more toilet paper.";
        }
        else if(healthBar.value == 0)
        {
            gameOverText.text = "Another shopper desperate to hoard their own toiler paper stole yours, you got so mad that you had a heart attack and collapsed.";
        }
        else if(stayHomeWasPressed)
        {
            gameOverText.text = "A true hoarder never stops buying and you chose to stay home...you have failed your family as you have only " + totalRollsOfToiletPaper + " out of 100 rolls that you wanted.";
        }

    }
}
