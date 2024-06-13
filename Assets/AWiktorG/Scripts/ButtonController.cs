using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // Referencje do trzech przycisk�w
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    // Referencja do obiektu, kt�ry ma si� uaktywni�
    public GameObject objectToActivate;

    private bool isButton1Pressed = false;
    private bool isButton2Pressed = false;
    private bool isButton3Pressed = false;

    void Start()
    {
        // Upewnij si�, �e obiekt do aktywacji jest na pocz�tku nieaktywny
        objectToActivate.SetActive(false);
    }

    void Update()
    {
        // Sprawd�, czy wszystkie przyciski s� wci�ni�te
        if (isButton1Pressed && isButton2Pressed && isButton3Pressed)
        {
            // Aktywuj obiekt
            objectToActivate.SetActive(true);
        }
    }

    public void OnButton1Pressed()
    {
        isButton1Pressed = true;
    }

    public void OnButton2Pressed()
    {
        isButton2Pressed = true;
    }

    public void OnButton3Pressed()
    {
        isButton3Pressed = true;
    }
}
