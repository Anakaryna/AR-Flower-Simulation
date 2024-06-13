/*
 * GameManager script manages game flow by tracking the number of cubes picked up and checking for win/lose conditions.
 */

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text resultText;
    public float timeLimit = 20f;
    public string menuSceneName = "Menu";
    private TimerManager timerManager;
    private int cubeCount = 0;

    // Start() initializes the TimerManager component.
    private void Start()
    {
        // Get the TimerManager component from the scene
        timerManager = FindObjectOfType<TimerManager>();
    }

    // Update() checks for win/lose conditions and updates the resultText accordingly.
    private void Update()
    {
        // Check if the user has picked up all eight cubes
        if (cubeCount == 8)
        {
            // Display "You won" on the screen
            resultText.text = "You won!";
            // Stop the timer
            timerManager.StopTimer();
            // Load the menu scene after a delay of 2 seconds
            Invoke("LoadMenuScene", 3f);
        }
        else if (timerManager.GetElapsedTime() > timeLimit)
        {
            // Display "You lose" on the screen
            resultText.text = "You lose!";
            // Load the menu scene after a delay of 2 seconds
            Invoke("LoadMenuScene", 3f);
        }
    }

    // LoadMenuScene() loads the menu scene.
    private void LoadMenuScene()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    // IncrementCubeCount() increases the number of picked up cubes.
    public void IncrementCubeCount()
    {
        cubeCount++;
    }
}