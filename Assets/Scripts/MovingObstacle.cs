using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public Transform pointA; // Punkt pocz�tkowy
    public Transform pointB; // Punkt ko�cowy
    public float speed = 2.0f; // Pr�dko�� przesuwania

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

