/*
* (Christopher Green)
* (HealthState.cs)
* (Assignment 9)
* (This script defines the abstract class with the methods that the states will derive from.)
*/
using UnityEngine;
public abstract class HealthState : MonoBehaviour
{
    public abstract void FullHealth(); // This heals the player
    public abstract void HalfHealth(); // This hurts the player but increases infection rate.
    public abstract void NoHealth(); // This allos the player to cleanse a small portion of infection.
}
