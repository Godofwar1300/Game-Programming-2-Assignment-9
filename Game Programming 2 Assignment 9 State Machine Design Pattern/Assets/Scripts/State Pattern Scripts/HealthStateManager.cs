using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStateManager : MonoBehaviour
{
    public HealthState fullHealth { get; set; }

    public HealthState halfHealth { get; set; }

    public HealthState noHealth { get; set; }

    public HealthState currentState { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        fullHealth = gameObject.AddComponent<FullHealthState>();
        halfHealth = gameObject.AddComponent<HalfHealthState>();
        noHealth = gameObject.AddComponent<NoHealthState>();

        currentState = fullHealth;
    }

    public void FullHealth() { currentState.FullHealth(); }
    public void HalfHealth() { currentState.HalfHealth(); }
    public void NoHealth() { currentState.NoHealth(); }

}
