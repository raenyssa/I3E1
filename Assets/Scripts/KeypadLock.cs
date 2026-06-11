using UnityEngine;

public class KeypadLock : MonoBehaviour
{
    public string code = "1234"; // The correct code to unlock
    private string enterCode = ""; // The current input from the player

    public void AddDigit(string digit)
    {
        if (enterCode.Length < code.Length)
        {
            enterCode += digit; // Add the digit to the current input
            Debug.Log("Current code: " + enterCode); // Log the current input for debugging
        }
    }

    public void CheckCode()
    {
        if (enterCode == code)
        {
            Debug.Log("Unlocked!"); // The code is correct
            // Add logic to unlock the door or trigger an event
        }
        else
        {
            Debug.Log("Incorrect code. Try again."); // The code is incorrect
            enterCode = ""; // Reset the input
        }
    }

    public void clearCode()
    {
        enterCode = ""; // Clear the current input
        Debug.Log("Code cleared."); // Log that the code has been cleared
    }
}
