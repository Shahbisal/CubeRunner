using UnityEngine;

public class FallRestart : MonoBehaviour
{
    // The Y-coordinate below which the player will restart
    public float restartHeight = -35f;

    // The starting position of the player
    private Vector3 startPosition;
    // The starting rotation of the player
    private Quaternion startRotation;

    void Start()
    {
        // Save the player's initial position and rotation when the game starts
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        // Check if the player's Y position is below the restart height
        if (transform.position.y < restartHeight)
        {
            // If it is, move the player back to their start position
            transform.position = startPosition;
            // And reset their rotation to the original rotation
            transform.rotation = startRotation;
        }
    }
}