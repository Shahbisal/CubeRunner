using UnityEngine;

public class ObstacleZMovement : MonoBehaviour
{
    public float speed = 3f;          // Movement speed
    public float moveDistance = 5f;   // How far it moves forward/backward

    private Vector3 startPos;
    private bool movingForward = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (movingForward)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;

            if (transform.position.z >= startPos.z + moveDistance)
                movingForward = false;
        }
        else
        {
            transform.position -= Vector3.forward * speed * Time.deltaTime;

            if (transform.position.z <= startPos.z - moveDistance)
                movingForward = true;
        }
    }
}
