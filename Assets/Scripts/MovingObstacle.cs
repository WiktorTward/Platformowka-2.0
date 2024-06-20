using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public Transform pointA; // Punkt pocz¹tkowy
    public Transform pointB; // Punkt koñcowy
    public float speed = 2.0f; // Prêdkoœæ przesuwania

    private Vector3 target;

    void Start()
    {
        target = pointB.position;
    }

    void Update()
    {
        MoveObstacle();
    }

    void MoveObstacle()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position == target)
        {
            target = target == pointA.position ? pointB.position : pointA.position;
        }
    }
}

