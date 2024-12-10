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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDiceRoll(int result)
    {
       PlayerMover mover = pelaaja.GetComponent<PlayerMover>();
       
    }
}
