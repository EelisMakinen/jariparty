using UnityEngine;

public class DiceThrow : MonoBehaviour
{
    public float throwForce = 12f;  // Adjust for the force applied when throwing the dice
    public float torqueForce = 10f; // Adjust for the torque applied to spin the dice
    public bool canthrow = true;

    private Rigidbody rb;

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
    }
    private void Update()
    {
        if (rb.IsSleeping() ) { canthrow = true;
            int x = Mathf.RoundToInt(rb.rotation.eulerAngles.x);
            int y = Mathf.RoundToInt(rb.rotation.eulerAngles.y);
            int z = Mathf.RoundToInt(rb.rotation.eulerAngles.z);
            if (x < 0) { x += 360; } 
             if (x > 360) { x -= 360; }
            if (y < 0) { y += 360; }
            if (y > 360) { y -= 360; }
            if (z < 0) { z += 360; }
            if (z > 360) { z -= 360; }
             
           
            if (x == 270 && y == -180) { } //yksi
            if (x == 180 && z == 180) { } // kaksi
            if (x == 180 && z == 90) { } // kolme
            if (x == 540 && z == 270) { } // neljä
            if (x ==540 && z == 360) { } // viisi
            if (x == 810 && y == -180) { } // kuusi


        
        
        
        
        
        }


    }
}
