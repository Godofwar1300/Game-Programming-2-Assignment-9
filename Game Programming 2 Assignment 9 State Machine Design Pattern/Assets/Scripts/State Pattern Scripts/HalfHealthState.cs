/*
* (Christopher Green)
* (HalfHealth.cs)
* (Assignment 9)
* (This script defines what the HalfHealth state does.)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfHealthState : HealthState
{

    public GameController gameCon;
    public HealthStateManager healthStateManager;

    private void Start()
    {
        gameCon = gameObject.GetComponent<GameController>();
        healthStateManager = gameObject.GetComponent<HealthStateManager>();
    }

    public override void FullHealth()
    {
        Debug.Log("You no longer have full health!");
        if (gameCon.healthBar.value == 100)
        {
            healthStateManager.currentState = healthStateManager.fullHealth;
        }
    }

    public override void HalfHealth()
    {
        Debug.Log("You have half health right now!");
        gameCon.descriptionText.text = "You are at half health, or close to it, but you better be careful and don't forget to keep buying that toilet paper! \n\n TP Stock: " + gameCon.totalRollsOfToiletPaper + " / 100";
    }

    public override void NoHealth()
    {
        Debug.Log("You are not dead yet!");
        if (gameCon.healthBar.value < 25)
        {
            healthStateManager.currentState = healthStateManager.noHealth;
        }
    }

    //public override void fullHealthMessage()
    //{
    //    gameCon.descriptionText.text = "You're not at full health anymore!";
    //}

    //public override void halfHealthMessage()
    //{
    //    gameCon.descriptionText.text = "You are at half / a level close to half health, you better be careful!\n\nA reminder of you current wellbeing:\nHealth: %" + gameCon.healthBar.value + "\tInfection: %" + gameCon.infectionPercentage;
    //}

    //public override void noHealthMessage()
    //{
    //    gameCon.descriptionText.text = "You're not dead yet!";
    //}
}
