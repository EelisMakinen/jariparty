using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceThrow : MonoBehaviour
{
    public float throwForce = 12f;  // Adjust for the force applied when throwing the dice
    public float torqueForce = 10f; // Adjust for the torque applied to spin the dice
    public bool canthrow = true;
    public int Value = 0;
    private string lastsidehit;
    public void OnSideHit(string sidenumber) {lastsidehit = sidenumber; }
    public event EventHandler<int> Diceresultevent;
    private Rigidbody rb;

    public bool isValueSetAfterThrow { get; private set; }

    void Start()
    {
        // Get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();
    }

    public void ThrowDice()
    { if (canthrow == false) {return;} canthrow = false;
        // Reset velocity and angular velocity to ensure a clean throw each time
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.MovePosition(transform.position + Vector3.up*10);

        // Apply a random directional force
        Vector3 randomDirection = new Vector3(
            Random.Range(-1f, 1f), // Random x direction
            Random.Range(0.5f, 1f), // Positive y direction to lift the dice
            Random.Range(-1f, 1f)  // Random z direction
        ).normalized;

        rb.AddForce(randomDirection * throwForce, ForceMode.Impulse);

        // Apply a random torque (spin) to the dice
        Vector3 randomTorque = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized;

        rb.AddTorque(randomTorque * torqueForce, ForceMode.Impulse);
        isValueSetAfterThrow = false;
    }
    private void Update()
    {
       

        
        /*if (rb.IsSleeping() ) { canthrow = true;
            int x = Mathf.RoundToInt(rb.rotation.eulerAngles.x);
            int y = Mathf.RoundToInt(rb.rotation.eulerAngles.y);
            int z = Mathf.RoundToInt(rb.rotation.eulerAngles.z);
            if (x < 0) { x += 360; } 
             if (x > 360) { x -= 360; }
            if (y < 0) { y += 360; }
            if (y > 360) { y -= 360; }
            if (z < 0) { z += 360; }
            if (z > 360) { z -= 360; }
             
           
            if (x == 270 && y == -180) { Value = 1; } 
            if (x == 180 && z == 180) { Value = 2; }
            if (x == 180 && z == 90) { Value = 3; }
            if (x == 540 && z == 270) { Value = 4; }
            if (x == 540 && z == 360) { Value = 5; }
            if (x == 810 && y == -180) { Value = 6; }

            */ //if (Value == 1) { Console.WriteLine("numero 1"); }


        
        
       
        
        
        }

    private void FixedUpdate()
    {
        if (rb.IsSleeping() && !canthrow) { 
            if (lastsidehit == "tulos 1") { Value = 1; }
            else if (lastsidehit == "tulos 2") { Value = 2; }
            else if (lastsidehit == "tulos 3") { Value = 3; }
            else if (lastsidehit == "tulos 4") { Value = 4; }
            else if (lastsidehit == "tulos 5") { Value = 5; }
            else if (lastsidehit == "tulos 6") { Value = 6; }
            Debug.Log("Value: "+ Value);
            isValueSetAfterThrow = true;
            canthrow = true;
            Diceresultevent.Invoke(this, Value);
        }
    }
}
