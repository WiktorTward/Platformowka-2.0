using UnityEngine;

public class InteractiveButton : MonoBehaviour
{
    public ButtonController buttonController;
    public int buttonNumber;

    void OnMouseDown()
    {
        if (buttonNumber == 1)
            buttonController.OnButton1Pressed();
        else if (buttonNumber == 2)
            buttonController.OnButton2Pressed();
        else if (buttonNumber == 3)
            buttonController.OnButton3Pressed();
    }
}
