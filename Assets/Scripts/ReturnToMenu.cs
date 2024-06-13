/*
 * ReturnToMenu script handles returning to the main menu by loading the "Menu" scene.
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    // GoBackToMenu() loads the "Menu" scene.
    public void GoBackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}