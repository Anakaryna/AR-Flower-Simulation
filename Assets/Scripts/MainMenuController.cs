/*
 * MainMenuController script is responsible for handling main menu interactions, such as loading different scenes or quitting the game.
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // LoadOption1() loads the "MovingObject" scene.
    public void LoadOption1()
    {
        SceneManager.LoadScene("MovingObject");
    }

    // LoadOption2() loads the "PickUpObjects" scene.
    public void LoadOption2()
    {
        SceneManager.LoadScene("PickUpObjects");
    }

    // QuitGame() quits the application.
    public void QuitGame()
    {
        Application.Quit();
    }
}