using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public enum MoveDirection { LeftRight, UpDown, ForwardBackward }
    public MoveDirection direction = MoveDirection.LeftRight;

    public float speed = 3f;          // Movement speed
    public float moveDistance = 5f;   // Distance from start position

    private Vector3 startPos;
    private bool movingPositive = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 axis = Vector3.zero;

        // Choose movement axis
        switch (direction)
        {
            case MoveDirection.LeftRight:
                axis = Vector3.right;
                break;
            case MoveDirection.UpDown:
                axis = Vector3.up;
                break;
            case MoveDirection.ForwardBackward:
                axis = Vector3.forward;
                break;
        }

        if (movingPositive)
        {
            transform.position += axis * speed * Time.deltaTime;

            if (Vector3.Dot(transform.position - startPos, axis) >= moveDistance)
                movingPositive = false;
        }
        else
        {
            transform.position -= axis * speed * Time.deltaTime;

            if (Vector3.Dot(transform.position - startPos, axis) <= -moveDistance)
                movingPositive = true;
        }
    }
}
