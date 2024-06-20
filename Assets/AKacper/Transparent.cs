using UnityEngine;

public class Transparent : MonoBehaviour
{
    // Publiczna zmienna materia�u, aby mo�na by�o przypisa� j� w Inspectorze
    public Material transparentMaterial;

    // Warto�� przezroczysto�ci od 0 (ca�kowicie przezroczysty) do 1 (ca�kowicie nieprzezroczysty)
    public float alpha = 0.5f;

    void Start()
    {
        // Ustaw przezroczysto�� na pocz�tku
        UpdateTransparency(alpha);
    }

    public void UpdateTransparency(float newAlpha)
    {
        // Upewnij si�, �e materia� nie jest null
        if (transparentMaterial != null)
        {
            Color color = transparentMaterial.color;
            color.a = newAlpha;
            transparentMaterial.color = color;
        }
        else
        {
            Debug.LogError("Transparent Material is not assigned.");
        }
    }
}
