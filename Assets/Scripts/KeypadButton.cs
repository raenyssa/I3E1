using UnityEngine;

public class KeypadButton : MonoBehaviour
{
    public KeypadLock keypadLock; // Reference to the KeypadLock script
    public string digitOrAction; // The digit or action this button represents

    public void pressButton()
    {
        if (digitOrAction == "Enter")
        {
            keypadLock.clearCode(); // Clear the code if the button is the clear button
        }
        else if (digitOrAction == "Clear")
        {
            keypadLock.CheckCode(); // Check the code if the button is the enter button
        }
        else
        {
            keypadLock.AddDigit(digitOrAction); // Add the digit to the code input
        }
    }
}
