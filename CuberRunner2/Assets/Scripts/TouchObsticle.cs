using UnityEngine;

public class RespawnObstacle : MonoBehaviour
{
    private Vector3 startPosition;     // Player starting position
    private Quaternion startRotation;  // Player starting rotation
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Save start position & rotation
        startPosition = player.position;
        startRotation = player.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RespawnPlayer(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RespawnPlayer(other.gameObject);
        }
    }

    void RespawnPlayer(GameObject playerObj)
    {
        // Reset position & rotation
        player.position = startPosition;
        player.rotation = startRotation;

        // Reset physics
        Rigidbody rb = playerObj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
