using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelinHallinta : MonoBehaviour
{
    public GameObject pelaaja;
    public GameObject noppa;

    // Start is called before the first frame update
    void Start()
    {
        noppa.GetComponent<DiceThrow>().Diceresultevent += OnDiceRoll;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDiceRoll(object sender, int result)
    {
       PlayerMover mover = pelaaja.GetComponent<PlayerMover>();
        mover.targetPoint += result;
    }
}
