using UnityEngine;

public class TransparencyController : MonoBehaviour
{
    public Material transparentMaterial;
    public float alpha = 0.1f; // warto�� przezroczysto�ci od 0 (ca�kowicie przezroczysty) do 1 (ca�kowicie nieprzezroczysty)

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
