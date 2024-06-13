/*
 * MoveCubeButton script handles the placement and movement of a cube object using a UI button and Vuforia's PlaneFinderBehaviour.
 */

using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class MoveCubeButton : MonoBehaviour
{
    public Button moveButton;
    private PlaneFinderBehaviour planeFinderBehaviour;
    private HitTestResult lastHitTestResult;
    private bool hasHitTestResult = false;
    private GameObject flowerInstance;

    void Start()
    {
        // Get the PlaneFinderBehaviour component
        planeFinderBehaviour = FindObjectOfType<PlaneFinderBehaviour>();
        planeFinderBehaviour.OnAutomaticHitTest.AddListener(OnAutomaticHitTest);

        // Add a listener for the button click event
        moveButton.onClick.AddListener(OnMoveButtonClick);
    }

    public void OnAutomaticHitTest(HitTestResult result)
    {
        // Store the last hit test result
        lastHitTestResult = result;
        hasHitTestResult = true;
    }

    // OnMoveButtonClick() moves the flower to the last hit test result position and rotation.
    void OnMoveButtonClick()
    {
        // Check if there is a valid hit test result
        if (hasHitTestResult && flowerInstance != null)
        {
            // Move the flower to the new position
            flowerInstance.transform.position = lastHitTestResult.Position;
            flowerInstance.transform.rotation = lastHitTestResult.Rotation;
        }
    }

    // Method to set the reference to the flower instance
    public void SetFlowerInstance(GameObject flower)
    {
        flowerInstance = flower;
    }

    void OnDestroy()
    {
        // Unregister this script as an input listener if it is still registered
        if (planeFinderBehaviour != null)
        {
            planeFinderBehaviour.OnAutomaticHitTest.RemoveListener(OnAutomaticHitTest);
        }
    }
}
