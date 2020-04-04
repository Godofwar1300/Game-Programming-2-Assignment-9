/*
* (Christopher Green)
* (FullHealth.cs)
* (Assignment 9)
* (This script defines what the FullHealth state does.)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullHealthState : HealthState
{
    public GameController gameCon;
    public HealthStateManager healthStateManager;

    private void Start()
    {
        //gameCon = GameObject.Find("Game Controller").GetComponent<GameController>();
        gameCon = gameObject.GetComponent<GameController>();
        healthStateManager = gameObject.GetComponent<HealthStateManager>();
    }

    public override void FullHealth()
    {
        Debug.Log("fulfullHealthMessage is being called!");
        //gameConDescriptionText.text = "You are at full / a high level of health, good job!";
        gameCon.descriptionText.text = "You are at full / a high level of health, good job!";
    }

    public override void HalfHealth()
    {
        Debug.Log("You currently have full health");
        if (gameCon.healthBar.value <= 75)
        {
            healthStateManager.currentState = healthStateManager.halfHealth;
        }
    }

    public override void NoHealth()
    {
        Debug.Log("You are not dead yet!");
    }

    //public override void FullHealth()
    //{
    //    Debug.Log("fulfullHealthMessage is being called!");
    //    gameCon.descriptionText.text = "You are at full / a high level of health, good job!\n\nA reminder of you current wellbeing:\nHealth: %" + gameCon.healthBar.value + "\tInfection: %" + gameCon.infectionPercentage;
    //}

    //public override void HalfHealth()
    //{
    //    Debug.Log("You are still within the full health range");
    //}

    //public override void NoHealth()
    //{
    //    Debug.Log("You are at full health, you cannot die with full health!");
    //}  
}
