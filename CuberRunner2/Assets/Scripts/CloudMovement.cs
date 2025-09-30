using UnityEngine;

public class CoinUpDown : MonoBehaviour
{
    public float amplitude = 0.5f; // How high/low it moves
    public float speed = 2f;       // How fast it moves

    private Vector3 startPos;

    void Start()
    {
        // Store the starting position
        startPos = transform.position;
    }

    void Update()
    {
        // Move coin up and down
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
