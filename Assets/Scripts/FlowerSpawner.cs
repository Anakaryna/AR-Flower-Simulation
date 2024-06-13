using UnityEngine;
using Vuforia;

public class FlowerSpawner : MonoBehaviour
{
    public GameObject flowerArrangementPrefab;
    private PlaneFinderBehaviour planeFinderBehaviour;
    private bool flowersSpawned = false;

    void Start()
    {
        // Get the PlaneFinderBehaviour component
        planeFinderBehaviour = FindObjectOfType<PlaneFinderBehaviour>();
        planeFinderBehaviour.OnInteractiveHitTest.AddListener(OnInteractiveHitTest);
    }

    void OnInteractiveHitTest(HitTestResult result)
    {
        if (!flowersSpawned)
        {
            // Check if the user tapped the screen
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                // Spawn the flower arrangement at the hit test result position
                Instantiate(flowerArrangementPrefab, result.Position, result.Rotation);

                // Set the flowersSpawned flag to true
                flowersSpawned = true;

                // Unregister this script as an input listener
                if (planeFinderBehaviour != null)
                {
                    planeFinderBehaviour.OnInteractiveHitTest.RemoveListener(OnInteractiveHitTest);
                }
            }
        }
    }
}