/*
* (Christopher Green)
* (HealthState.cs)
* (Assignment 9)
* (This script defines the abstract class with the methods that the states will derive from.)
*/
using UnityEngine;
public abstract class HealthState : MonoBehaviour
{
    public abstract void FullHealth();
    public abstract void HalfHealth();
    public abstract void LowHealth();
    public abstract void NoHealth();
}
