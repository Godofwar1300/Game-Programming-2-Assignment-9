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

    GameController gameCon;

    private void Start()
    {
        gameCon = gameObject.GetComponent<GameController>();
    }

    public override void FullHealth()
    {
        throw new System.NotImplementedException();
    }

    public override void HalfHealth()
    {
        gameCon.descriptionText.text = "You are at half / a level close to half health, you better be careful!\n\nA reminder of you current wellbeing:\nHealth: %" + gameCon.healthBar.value + "\tInfection: %" + gameCon.infectionPercentage;
    }

    public override void NoHealth()
    {
        throw new System.NotImplementedException();
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
