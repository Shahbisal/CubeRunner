using UnityEngine;

public class ChildObstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over! Player hit obstacle from child: " + gameObject.name);
            Time.timeScale = 0f; // Stop the game
        }
    }
}
