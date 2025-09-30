using UnityEngine;

public class Coin : MonoBehaviour
{
    // Public variable for rotation speed, adjustable in the Inspector
    public float rotationSpeed = 100f;
    public int points = 1;
    public AudioClip coinSound; // Add this line-------------------------------------------------------------------------------------

    // This will hold a reference to the Punitha script
    private PunithaAnimationHandler punithaHandler;

    void Start()
    {
        // Find the Punitha object and get a reference to its script
        GameObject punithaObject = GameObject.Find("punitha");
        if (punithaObject != null)
        {
            punithaHandler = punithaObject.GetComponent<PunithaAnimationHandler>();
        }
    }

    void Update()
    {
        // This makes the coin spin around the Y-axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

//    void OnTriggerEnter(Collider other)
//    {
//        // Check if the object that entered the trigger is the player
//        if (other.CompareTag("Player"))
//        {
//            Debug.Log("Coin Collected!");

//            // Check if the Punitha script reference is valid and call the animation method
//            if (punithaHandler != null)
//{
//    punithaHandler.RunAnimationForSeconds(1.0f); // Now it's 1 second
//}

//            // Disable the coin so it disappears
//            gameObject.SetActive(false);
//        }

//    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin Collected!");







            // Inside your OnTriggerEnter(Collider other) function
            // After the Debug.Log("Coin Collected!") line

            // Find the ScoreManager script in the scene
            ScoreManager scoreManager = FindAnyObjectByType<ScoreManager>();

            // If the ScoreManager is found, call its AddPoints method
            if (scoreManager != null)
            {
                ScoreManager.AddPoints(points); // Adds 1 point to the score
            }








            // Play the coin sound here
            if (coinSound != null)
            {
                AudioSource.PlayClipAtPoint(coinSound, transform.position);
            }

            // Call the Punitha animation handler as before
            if (punithaHandler != null)
            {
                punithaHandler.RunAnimationForSeconds(1.0f);
            }

            // Disable the coin (or destroy it, but disabling is fine)
            gameObject.SetActive(false);

        }
    }



}

