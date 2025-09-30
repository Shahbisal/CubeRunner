using UnityEngine;

public class FallWhenClose : MonoBehaviour
{
    public Transform player;          // Assign your player here
    public float triggerDistance = 5f; // Distance before it falls
    public float fallDelay = 0.3f;     // Optional delay before falling

    private Rigidbody rb;
    private bool hasFallen = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // Start frozen
    }

    void Update()
    {
        if (!hasFallen && player != null)
        {
            float distance = Vector3.Distance(player.position, transform.position);

            if (distance < triggerDistance)
            {
                hasFallen = true;
                Invoke(nameof(MakeFall), fallDelay);
            }
        }
    }

    void MakeFall()
    {
        rb.isKinematic = false; // Enable gravity → falls
    }
}
