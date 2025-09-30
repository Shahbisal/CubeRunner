using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Call this function from the Play button
    public void PlayGame()
    {
        // Loads the next scene (make sure your scenes are added in Build Settings)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Call this function from the Quit button
    public void QuitGame()
    {
        Debug.Log("Quit!");  // Works in Editor
        Application.Quit();   // Works in build
    }
}
