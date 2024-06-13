/*
 * CubePlacementListener script listens for touch input and starts a timer after a specified number of clicks.
 */

using UnityEngine;

public class CubePlacementListener : MonoBehaviour
{
    public int numberOfClicksToSpawnCubes = 1;
    private int currentClicks = 0;

    // Update() checks for touch input and starts a timer after the specified number of clicks.
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            currentClicks++;

            if (currentClicks >= numberOfClicksToSpawnCubes)
            {
                TimerManager timerManager = FindObjectOfType<TimerManager>();
                if (timerManager != null)
                {
                    timerManager.StartTimer();
                }
            }
        }
    }
}