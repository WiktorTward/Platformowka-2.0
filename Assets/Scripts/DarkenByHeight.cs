using UnityEngine;

public class DarkenByHeight : MonoBehaviour
{
    public Transform character; // Referencja do postaci
    public Light mainLight; // Referencja do g��wnego �r�d�a �wiat�a

    public float minHeight = 0f; // Minimalna wysoko�� postaci
    public float maxHeight = 10f; // Maksymalna wysoko�� postaci
    public float minIntensity = 1f; // Minimalna intensywno�� �wiat�a
    public float maxIntensity = 5f; // Maksymalna intensywno�� �wiat�a

    void Update()
    {
        // Pobierz wysoko�� postaci
        float height = character.position.y;

        // Zastosuj odpowiedni� intensywno�� �wiat�a w zale�no�ci od wysoko�ci postaci
        float intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.InverseLerp(minHeight, maxHeight, height));
        mainLight.intensity = intensity;
    }
}
