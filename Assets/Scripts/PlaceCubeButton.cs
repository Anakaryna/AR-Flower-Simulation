/*
 * PlaceCubeButton script handles the placement of a cube object on a surface using Vuforia's PlaneFinderBehaviour.
 */

using UnityEngine;
using Vuforia;

public class PlaceCubeButton : MonoBehaviour
{
    public GameObject flowerPrefab; 
    private PlaneFinderBehaviour planeFinderBehaviour;
    private bool flowerPlaced = false;
    private MoveCubeButton moveCubeButton;

    void Start()
    {
        // Get the PlaneFinderBehaviour component
        planeFinderBehaviour = FindObjectOfType<PlaneFinderBehaviour>();
        planeFinderBehaviour.OnInteractiveHitTest.AddListener(OnInteractiveHitTest);

        // Find the MoveCubeButton script
        moveCubeButton = FindObjectOfType<MoveCubeButton>();
    }

    public void OnInteractiveHitTest(HitTestResult result)
    {
        if (!flowerPlaced)
        {
            // Check if the user tapped the screen
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                // Place the flower at the hit test result position and rotation
                GameObject flowerInstance = Instantiate(flowerPrefab, result.Position, result.Rotation);

                // Inform the MoveCubeButton script about the placed flower instance
                moveCubeButton.SetFlowerInstance(flowerInstance);

                // Set the flowerPlaced flag to true
                flowerPlaced = true;

                // Unregister this script as an input listener
                if (planeFinderBehaviour != null)
                {
                    planeFinderBehaviour.OnInteractiveHitTest.RemoveListener(OnInteractiveHitTest);
                }
            }
        }
    }
}
