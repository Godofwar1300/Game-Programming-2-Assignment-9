/*
* (Christopher Green)
* (NoHealthState.cs)
* (Assignment 9)
* (This script defines what the NoHealth state does.)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoHealthState : HealthState
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
        Debug.Log("You are dead and cannot heal.");
    }

    public override void HalfHealth()
    {
        Debug.Log("You are dead and cannot heal.");
    }

    public override void NoHealth()
    {
        gameCon.descriptionText.text = "You have died";
    }

    //public override void fullHealthMessage()
    //{
    //    Debug.Log("You're not at full health anymore!");
    //}

    //public override void halfHealthMessage()
    //{
    //    Debug.Log("You are no longer at half health");
    //}

    //public override void noHealthMessage()
    //{
    //    gameCon.descriptionText.text = "You have died";
    //    gameCon.StartCoroutine(gameCon.GameOver());
    //}
}
