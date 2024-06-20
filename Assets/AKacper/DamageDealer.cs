using UnityEngine;

public class TransparencyController : MonoBehaviour
{
    public Material transparentMaterial;
    public float alpha = 0.1f; // wartoœæ przezroczystoœci od 0 (ca³kowicie przezroczysty) do 1 (ca³kowicie nieprzezroczysty)

    void Start()
    {
        SetTransparency(alpha);
    }

    void SetTransparency(float alpha)
    {
        Color color = transparentMaterial.color;
        color.a = alpha;
        transparentMaterial.color = color;
    }
}
