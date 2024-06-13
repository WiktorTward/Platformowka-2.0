using UnityEngine;

public class Button2 : MonoBehaviour
{
    public ButtonController buttonController;

    void OnMouseDown()
    {
        buttonController.OnButton2Pressed();
    }
}
