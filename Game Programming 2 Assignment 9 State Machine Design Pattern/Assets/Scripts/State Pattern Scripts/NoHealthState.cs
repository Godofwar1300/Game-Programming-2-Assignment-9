using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoHealthState : HealthState
{

    GameController gameCon;

    private void Start()
    {
        //gameCon = GameObject.Find("Game Controller").GetComponent<GameController>();
        gameCon = gameObject.GetComponent<GameController>();
    }

    public override void FullHealth()
    {
        Debug.Log("You're not at full health anymore!");
    }

    public override void HalfHealth()
    {
        Debug.Log("You are no longer at half health");
    }

    public override void NoHealth()
    {
        gameCon.descriptionText.text = "You have died";
        gameCon.StartCoroutine(gameCon.GameOver());
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
