using UnityEngine;

public class Button3 : MonoBehaviour
{
    public ButtonController buttonController;

    void OnMouseDown()
    {
        buttonController.OnButton3Pressed();
    }
}
