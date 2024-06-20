using UnityEngine;

public class Transparent : MonoBehaviour
{
    // Publiczna zmienna materia³u, aby mo¿na by³o przypisaæ j¹ w Inspectorze
    public Material transparentMaterial;

    // Wartoœæ przezroczystoœci od 0 (ca³kowicie przezroczysty) do 1 (ca³kowicie nieprzezroczysty)
    public float alpha = 0.5f;

    void Start()
    {
        // Ustaw przezroczystoœæ na pocz¹tku
        UpdateTransparency(alpha);
    }

    public void UpdateTransparency(float newAlpha)
    {
        // Upewnij siê, ¿e materia³ nie jest null
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
