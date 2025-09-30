using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over! Player hit an obstacle.");
            Time.timeScale = 0f; // Pause the whole game
        }
    }
}
