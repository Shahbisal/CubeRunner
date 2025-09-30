using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    // A variable to hold the sound effect
    public AudioClip coinSound;

    // This runs when the player touches another object with a trigger collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the object we touched is a coin
        if (other.CompareTag("Coin"))
        {
            // Play the sound effect
            if (coinSound != null)
            {
                AudioSource.PlayClipAtPoint(coinSound, transform.position);
            }

            // Make the coin disappear
            Destroy(other.gameObject);
        }
    }
}