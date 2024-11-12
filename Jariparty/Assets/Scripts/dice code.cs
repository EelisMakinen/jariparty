using UnityEngine;

public class Dice : MonoBehaviour
{
    public int numberOfSides = 6; // Standard dice has 6 sides
    private int currentRoll;

    // Method to simulate rolling the dice
    public void RollDice()
    {
        // Randomly generate a number between 1 and numberOfSides
        currentRoll = Random.Range(1, numberOfSides + 1);
        Debug.Log("Dice rolled: " + currentRoll);
    }

    // Optional: Method to get the result of the last roll
    public int GetRollResult()
    {
        return currentRoll;
    }
}
