using UnityEngine;

public class TransparencyController : MonoBehaviour
{
    public Material transparentMaterial;
    public float alpha = 0.1f; // wartość przezroczystości od 0 (całkowicie przezroczysty) do 1 (całkowicie nieprzezroczysty)

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
