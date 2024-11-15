using UnityEngine;

public class DiceController : MonoBehaviour
{
    public DiceThrow diceThrow;

    void Update()
    {
        // Throw the dice when the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            diceThrow.ThrowDice();
        }
    }
}
