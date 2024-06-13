using UnityEngine;

public class PlayerController_nachos : MonoBehaviour
{
    public float speed = 40f;

    void Update()
    {
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector3 newPosition = transform.position + new Vector3(move, 0, 0);

        newPosition.x = Mathf.Clamp(newPosition.x, -40f, 40f);
        newPosition.z = 0; // Ensure player stays on the same Z plane
        transform.position = newPosition;
    }
}
