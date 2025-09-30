using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator animator;

    void Start()
    {
        // Get Animator attached to the same GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        // Move the cube
        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

        // Check if moving
        bool isMoving = move.magnitude > 0;

        // Send value to Animator
        animator.SetBool("isMoving", isMoving);
    }
}
