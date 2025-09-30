using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f; // how fast player turns

    [Header("Respawn Settings")]
    public float fallThreshold = -5f;
    public float stopSpeedThreshold = 0.1f;

    private Rigidbody rb;
    private Vector3 startPosition;
    private Vector3 targetDirection; // where player should turn towards

    [Header("Ground Check")]
    public float groundCheckDistance = 0.2f;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        startPosition = transform.position;

        targetDirection = Vector3.back; // Start moving in -Z direction
    }

    void Update()
    {
        // Ground check
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);

        // Change target direction on key press
        if (Input.GetKeyDown(KeyCode.A))
            targetDirection = Vector3.right;
        else if (Input.GetKeyDown(KeyCode.D))
            targetDirection = Vector3.left;
        else if (Input.GetKeyDown(KeyCode.S))
            targetDirection = Vector3.forward;
        else if (Input.GetKeyDown(KeyCode.W))
            targetDirection = Vector3.back;

        // Smoothly rotate towards targetDirection
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Always move forward after rotation
        Vector3 velocity = transform.forward * moveSpeed;
        velocity.y = rb.linearVelocity.y; // keep gravity/jump
        rb.linearVelocity = velocity;

        // Respawn if fallen
        if (transform.position.y < fallThreshold)
        {
            Respawn();
        }

        // Respawn if stopped
        if (rb.linearVelocity.magnitude < stopSpeedThreshold && isGrounded)
        {
            Respawn();
        }

        // Manual restart
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        targetDirection = Vector3.back; // Reset to -Z
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}
