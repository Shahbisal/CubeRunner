using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Reference to your UI Text element
    public static int scoreCount; // Static variable to hold the score

    // Start is called before the first frame update
    void Start()
    {
        scoreCount = 0; // Initialize score to zero
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreCount; // Update the UI text
    }

    // Method to add points
    public static void AddPoints(int pointsToAdd)
    {
        scoreCount += pointsToAdd; // Add points to the score
    }
}