using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public void GoToMenu()
    {
        // Replace "MainMenu" with the exact scene name of your menu
        SceneManager.LoadScene("Menu");
    }
}
