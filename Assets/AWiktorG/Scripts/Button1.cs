using UnityEngine;

public class Button1 : MonoBehaviour
{
    public ButtonController buttonController;

    void OnMouseDown()
    {
        buttonController.OnButton1Pressed();
    }
}
